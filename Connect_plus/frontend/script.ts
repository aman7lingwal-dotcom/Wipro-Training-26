interface Customer {
    customerId?: number;
    name: string;
    email: string;
    phone: string;
    createdAt?: string;
}

interface Ticket {
    ticketId?: number;
    customerId: number;
    categoryId: number;
    agentId: number;
    statusId: number;
    description: string;
    resolutionNotes: string;
    createdAt?: string;
    updatedAt?: string;
}

interface Category {
    categoryId: number;
    categoryName: string;
}

interface Agent {
    agentId: number;
    agentName: string;
}

interface TicketStatus {
    statusId: number;
    statusName: string;
}

interface TicketDetails {
    ticketId: number;
    customerName: string;
    categoryName: string;
    agentName: string;
    statusName: string;
    description: string;
    createdAt: string;
    resolutionNotes: string;
}

const apiBaseUrl: string = "http://localhost:5267/api";

function showSection(sectionId: string): void {
    const sections: string[] = [
        "dashboardSection",
        "ticketSection",
        "customerSection",
        "addCustomerSection",
        "addTicketSection"
    ];

    sections.forEach((id: string) => {
        const section = document.getElementById(id) as HTMLElement | null;
        if (section) {
            section.style.display = id === sectionId ? "block" : "none";
        }
    });
}

function formatDate(dateString: string): string {
    if (!dateString) return "";
    return new Date(dateString).toLocaleString();
}

function getStatusIdFromName(statusName: string): number {
    const status = statusName.toLowerCase().trim();

    if (status === "open") return 1;
    if (status === "in progress") return 2;
    if (status === "resolved") return 3;
    if (status === "closed") return 4;

    return 1;
}

async function loadDashboard(): Promise<void> {
    try {
        const ticketResponse = await fetch(`${apiBaseUrl}/Tickets/details`);
        if (!ticketResponse.ok) {
            throw new Error("Failed to fetch tickets for dashboard");
        }

        const customerResponse = await fetch(`${apiBaseUrl}/Customers`);
        if (!customerResponse.ok) {
            throw new Error("Failed to fetch customers for dashboard");
        }

        const agentResponse = await fetch(`${apiBaseUrl}/Agents`);
        if (!agentResponse.ok) {
            throw new Error("Failed to fetch agents for dashboard");
        }

        const tickets: TicketDetails[] = await ticketResponse.json();
        const customers: Customer[] = await customerResponse.json();
        const agents: Agent[] = await agentResponse.json();

        const totalTickets: number = tickets.length;
        const openTickets: number = tickets.filter((t: TicketDetails) => t.statusName.toLowerCase() === "open").length;
        const inProgressTickets: number = tickets.filter((t: TicketDetails) => t.statusName.toLowerCase() === "in progress").length;
        const closedTickets: number = tickets.filter((t: TicketDetails) => {
            const status = t.statusName.toLowerCase();
            return status === "resolved" || status === "closed";
        }).length;

        const totalTicketsEl = document.getElementById("totalTicketsCount");
        const openTicketsEl = document.getElementById("openTicketsCount");
        const inProgressTicketsEl = document.getElementById("inProgressTicketsCount");
        const closedTicketsEl = document.getElementById("closedTicketsCount");
        const totalCustomersEl = document.getElementById("totalCustomersCount");
        const totalAgentsEl = document.getElementById("totalAgentsCount");
        const recentTicketsTableBody = document.getElementById("recentTicketsTableBody");

        if (totalTicketsEl) totalTicketsEl.textContent = totalTickets.toString();
        if (openTicketsEl) openTicketsEl.textContent = openTickets.toString();
        if (inProgressTicketsEl) inProgressTicketsEl.textContent = inProgressTickets.toString();
        if (closedTicketsEl) closedTicketsEl.textContent = closedTickets.toString();
        if (totalCustomersEl) totalCustomersEl.textContent = customers.length.toString();
        if (totalAgentsEl) totalAgentsEl.textContent = agents.length.toString();

        if (recentTicketsTableBody) {
            recentTicketsTableBody.innerHTML = "";

            const recentTickets: TicketDetails[] = [...tickets]
                .sort((a: TicketDetails, b: TicketDetails) =>
                    new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
                )
                .slice(0, 5);

            recentTickets.forEach((ticket: TicketDetails) => {
                const row = `
                    <tr>
                        <td>${ticket.ticketId}</td>
                        <td>${ticket.customerName}</td>
                        <td>${ticket.statusName}</td>
                        <td>${ticket.description}</td>
                        <td>${formatDate(ticket.createdAt)}</td>
                    </tr>
                `;
                recentTicketsTableBody.innerHTML += row;
            });
        }
    } catch (error) {
        console.error("Error loading dashboard:", error);
    }
}

async function loadCustomers(): Promise<void> {
    try {
        const response = await fetch(`${apiBaseUrl}/Customers`);
        if (!response.ok) {
            throw new Error("Failed to fetch customers");
        }

        const customers: Customer[] = await response.json();
        const tableBody = document.getElementById("customerTableBody") as HTMLElement | null;

        if (!tableBody) return;

        tableBody.innerHTML = "";

        customers.forEach((customer: Customer) => {
            const row = `
                <tr>
                    <td>${customer.customerId ?? ""}</td>
                    <td>${customer.name}</td>
                    <td>${customer.email}</td>
                    <td>${customer.phone}</td>
                </tr>
            `;
            tableBody.innerHTML += row;
        });
    } catch (error) {
        console.error("Error loading customers:", error);
        alert("Failed to load customers.");
    }
}

async function loadTickets(): Promise<void> {
    try {
        const response = await fetch(`${apiBaseUrl}/Tickets/details`);
        if (!response.ok) {
            throw new Error("Failed to fetch tickets");
        }

        const tickets: TicketDetails[] = await response.json();
        const tableBody = document.getElementById("ticketTable") as HTMLElement | null;

        if (!tableBody) return;

        tableBody.innerHTML = "";

        tickets.forEach((ticket: TicketDetails) => {
            const selectedStatusId = getStatusIdFromName(ticket.statusName);

            const row = `
                <tr>
                    <td>${ticket.ticketId}</td>
                    <td>${ticket.customerName}</td>
                    <td>${ticket.categoryName}</td>
                    <td>${ticket.agentName}</td>
                    <td>${ticket.statusName}</td>
                    <td>${ticket.description}</td>
                    <td>${formatDate(ticket.createdAt)}</td>
                    <td>
                        <input 
                            type="text" 
                            class="form-control" 
                            id="notes-${ticket.ticketId}" 
                            value="${ticket.resolutionNotes || ""}"
                        >
                    </td>
                    <td>
                        <select class="form-select" id="status-${ticket.ticketId}">
                            <option value="1" ${selectedStatusId === 1 ? "selected" : ""}>Open</option>
                            <option value="2" ${selectedStatusId === 2 ? "selected" : ""}>In Progress</option>
                            <option value="3" ${selectedStatusId === 3 ? "selected" : ""}>Resolved</option>
                            <option value="4" ${selectedStatusId === 4 ? "selected" : ""}>Closed</option>
                        </select>
                    </td>
                    <td>
                        <button class="btn btn-primary btn-sm" onclick="updateTicket(${ticket.ticketId})">
                            Update
                        </button>
                    </td>
                </tr>
            `;
            tableBody.innerHTML += row;
        });
    } catch (error) {
        console.error("Error loading tickets:", error);
        alert("Failed to load tickets.");
    }
}

async function updateTicket(ticketId: number): Promise<void> {
    try {
        const statusElement = document.getElementById(`status-${ticketId}`) as HTMLSelectElement | null;
        const notesElement = document.getElementById(`notes-${ticketId}`) as HTMLInputElement | null;

        if (!statusElement || !notesElement) {
            alert("Ticket fields not found.");
            return;
        }

        const selectedStatus: number = parseInt(statusElement.value);
        const resolutionNotes: string = notesElement.value;

        const getResponse = await fetch(`${apiBaseUrl}/Tickets/${ticketId}`);
        if (!getResponse.ok) {
            throw new Error("Failed to fetch ticket by id");
        }

        const ticket: Ticket = await getResponse.json();

        ticket.statusId = selectedStatus;
        ticket.resolutionNotes = resolutionNotes;
        ticket.updatedAt = new Date().toISOString();

        const putResponse = await fetch(`${apiBaseUrl}/Tickets/${ticketId}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(ticket)
        });

        const putText = await putResponse.text();

        if (putResponse.ok) {
            alert("Ticket updated successfully.");
            await loadTickets();
            await loadDashboard();
        } else {
            console.error("Update ticket failed:", putText);
            alert(`Failed to update ticket. ${putText}`);
        }
    } catch (error) {
        console.error("Error updating ticket:", error);
        alert("Error updating ticket.");
    }
}

async function submitCustomer(event: Event): Promise<void> {
    event.preventDefault();

    const nameInput = document.getElementById("customerName") as HTMLInputElement | null;
    const emailInput = document.getElementById("customerEmail") as HTMLInputElement | null;
    const phoneInput = document.getElementById("customerPhone") as HTMLInputElement | null;

    if (!nameInput || !emailInput || !phoneInput) {
        alert("Customer form fields not found.");
        return;
    }

    const customer: Customer = {
        name: nameInput.value.trim(),
        email: emailInput.value.trim(),
        phone: phoneInput.value.trim()
    };

    if (!customer.name || !customer.email || !customer.phone) {
        alert("Please fill all customer fields.");
        return;
    }

    try {
        console.log("Sending customer:", customer);

        const response = await fetch(`${apiBaseUrl}/Customers`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(customer)
        });

        const responseText = await response.text();
        console.log("POST /Customers status:", response.status);
        console.log("POST /Customers response:", responseText);

        if (response.ok) {
            alert("Customer added successfully.");
            nameInput.value = "";
            emailInput.value = "";
            phoneInput.value = "";

            await loadCustomers();
            await loadDashboard();
            showSection("customerSection");
        } else {
            alert(`Failed to add customer. ${responseText}`);
        }
    } catch (error) {
        console.error("Error adding customer:", error);
        alert("Error adding customer. Check backend/API.");
    }
}

async function submitTicket(event: Event): Promise<void> {
    event.preventDefault();

    const customerIdInput = document.getElementById("ticketCustomerId") as HTMLInputElement | null;
    const categoryIdInput = document.getElementById("ticketCategoryId") as HTMLInputElement | null;
    const agentIdInput = document.getElementById("ticketAgentId") as HTMLInputElement | null;
    const statusIdInput = document.getElementById("ticketStatusId") as HTMLInputElement | null;
    const descriptionInput = document.getElementById("ticketDescription") as HTMLInputElement | null;

    if (
        !customerIdInput ||
        !categoryIdInput ||
        !agentIdInput ||
        !statusIdInput ||
        !descriptionInput
    ) {
        alert("Ticket form fields not found.");
        return;
    }

    const ticket: Ticket = {
        customerId: parseInt(customerIdInput.value),
        categoryId: parseInt(categoryIdInput.value),
        agentId: parseInt(agentIdInput.value),
        statusId: parseInt(statusIdInput.value),
        description: descriptionInput.value.trim(),
        createdAt: new Date().toISOString(),
        updatedAt: new Date().toISOString(),
        resolutionNotes: ""
    };

    if (
        isNaN(ticket.customerId) ||
        isNaN(ticket.categoryId) ||
        isNaN(ticket.agentId) ||
        isNaN(ticket.statusId) ||
        !ticket.description
    ) {
        alert("Please fill all ticket fields correctly.");
        return;
    }

    try {
        const response = await fetch(`${apiBaseUrl}/Tickets`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(ticket)
        });

        const responseText = await response.text();
        console.log("POST /Tickets status:", response.status);
        console.log("POST /Tickets response:", responseText);

        if (response.ok) {
            alert("Ticket added successfully.");
            customerIdInput.value = "";
            categoryIdInput.value = "";
            agentIdInput.value = "";
            statusIdInput.value = "";
            descriptionInput.value = "";

            await loadTickets();
            await loadDashboard();
            showSection("ticketSection");
        } else {
            alert(`Failed to add ticket. ${responseText}`);
        }
    } catch (error) {
        console.error("Error adding ticket:", error);
        alert("Error adding ticket.");
    }
}

document.addEventListener("DOMContentLoaded", async () => {
    const addCustomerForm = document.getElementById("addCustomerForm") as HTMLFormElement | null;
    const addTicketForm = document.getElementById("addTicketForm") as HTMLFormElement | null;

    if (addCustomerForm) {
        addCustomerForm.addEventListener("submit", submitCustomer);
    } else {
        console.error("addCustomerForm not found");
    }

    if (addTicketForm) {
        addTicketForm.addEventListener("submit", submitTicket);
    } else {
        console.error("addTicketForm not found");
    }

    showSection("dashboardSection");
    await loadDashboard();
    await loadTickets();
    await loadCustomers();
});

(window as any).showSection = showSection;
(window as any).updateTicket = updateTicket;
(window as any).submitCustomer = submitCustomer;
(window as any).submitTicket = submitTicket;
(window as any).loadCustomers = loadCustomers;
(window as any).loadTickets = loadTickets;
(window as any).loadDashboard = loadDashboard;