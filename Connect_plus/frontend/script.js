var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
const apiBaseUrl = "http://localhost:5267/api";
function showSection(sectionId) {
    const sections = [
        "dashboardSection",
        "ticketSection",
        "customerSection",
        "addCustomerSection",
        "addTicketSection"
    ];
    sections.forEach((id) => {
        const section = document.getElementById(id);
        if (section) {
            section.style.display = id === sectionId ? "block" : "none";
        }
    });
}
function formatDate(dateString) {
    if (!dateString)
        return "";
    return new Date(dateString).toLocaleString();
}
function getStatusIdFromName(statusName) {
    const status = statusName.toLowerCase().trim();
    if (status === "open")
        return 1;
    if (status === "in progress")
        return 2;
    if (status === "resolved")
        return 3;
    if (status === "closed")
        return 4;
    return 1;
}
function loadDashboard() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const ticketResponse = yield fetch(`${apiBaseUrl}/Tickets/details`);
            if (!ticketResponse.ok) {
                throw new Error("Failed to fetch tickets for dashboard");
            }
            const customerResponse = yield fetch(`${apiBaseUrl}/Customers`);
            if (!customerResponse.ok) {
                throw new Error("Failed to fetch customers for dashboard");
            }
            const agentResponse = yield fetch(`${apiBaseUrl}/Agents`);
            if (!agentResponse.ok) {
                throw new Error("Failed to fetch agents for dashboard");
            }
            const tickets = yield ticketResponse.json();
            const customers = yield customerResponse.json();
            const agents = yield agentResponse.json();
            const totalTickets = tickets.length;
            const openTickets = tickets.filter((t) => t.statusName.toLowerCase() === "open").length;
            const inProgressTickets = tickets.filter((t) => t.statusName.toLowerCase() === "in progress").length;
            const closedTickets = tickets.filter((t) => {
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
            if (totalTicketsEl)
                totalTicketsEl.textContent = totalTickets.toString();
            if (openTicketsEl)
                openTicketsEl.textContent = openTickets.toString();
            if (inProgressTicketsEl)
                inProgressTicketsEl.textContent = inProgressTickets.toString();
            if (closedTicketsEl)
                closedTicketsEl.textContent = closedTickets.toString();
            if (totalCustomersEl)
                totalCustomersEl.textContent = customers.length.toString();
            if (totalAgentsEl)
                totalAgentsEl.textContent = agents.length.toString();
            if (recentTicketsTableBody) {
                recentTicketsTableBody.innerHTML = "";
                const recentTickets = [...tickets]
                    .sort((a, b) => new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime())
                    .slice(0, 5);
                recentTickets.forEach((ticket) => {
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
        }
        catch (error) {
            console.error("Error loading dashboard:", error);
        }
    });
}
function loadCustomers() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const response = yield fetch(`${apiBaseUrl}/Customers`);
            if (!response.ok) {
                throw new Error("Failed to fetch customers");
            }
            const customers = yield response.json();
            const tableBody = document.getElementById("customerTableBody");
            if (!tableBody)
                return;
            tableBody.innerHTML = "";
            customers.forEach((customer) => {
                var _a;
                const row = `
                <tr>
                    <td>${(_a = customer.customerId) !== null && _a !== void 0 ? _a : ""}</td>
                    <td>${customer.name}</td>
                    <td>${customer.email}</td>
                    <td>${customer.phone}</td>
                </tr>
            `;
                tableBody.innerHTML += row;
            });
        }
        catch (error) {
            console.error("Error loading customers:", error);
            alert("Failed to load customers.");
        }
    });
}
function loadTickets() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const response = yield fetch(`${apiBaseUrl}/Tickets/details`);
            if (!response.ok) {
                throw new Error("Failed to fetch tickets");
            }
            const tickets = yield response.json();
            const tableBody = document.getElementById("ticketTable");
            if (!tableBody)
                return;
            tableBody.innerHTML = "";
            tickets.forEach((ticket) => {
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
        }
        catch (error) {
            console.error("Error loading tickets:", error);
            alert("Failed to load tickets.");
        }
    });
}
function updateTicket(ticketId) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const statusElement = document.getElementById(`status-${ticketId}`);
            const notesElement = document.getElementById(`notes-${ticketId}`);
            if (!statusElement || !notesElement) {
                alert("Ticket fields not found.");
                return;
            }
            const selectedStatus = parseInt(statusElement.value);
            const resolutionNotes = notesElement.value;
            const getResponse = yield fetch(`${apiBaseUrl}/Tickets/${ticketId}`);
            if (!getResponse.ok) {
                throw new Error("Failed to fetch ticket by id");
            }
            const ticket = yield getResponse.json();
            ticket.statusId = selectedStatus;
            ticket.resolutionNotes = resolutionNotes;
            ticket.updatedAt = new Date().toISOString();
            const putResponse = yield fetch(`${apiBaseUrl}/Tickets/${ticketId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(ticket)
            });
            const putText = yield putResponse.text();
            if (putResponse.ok) {
                alert("Ticket updated successfully.");
                yield loadTickets();
                yield loadDashboard();
            }
            else {
                console.error("Update ticket failed:", putText);
                alert(`Failed to update ticket. ${putText}`);
            }
        }
        catch (error) {
            console.error("Error updating ticket:", error);
            alert("Error updating ticket.");
        }
    });
}
function submitCustomer(event) {
    return __awaiter(this, void 0, void 0, function* () {
        event.preventDefault();
        const nameInput = document.getElementById("customerName");
        const emailInput = document.getElementById("customerEmail");
        const phoneInput = document.getElementById("customerPhone");
        if (!nameInput || !emailInput || !phoneInput) {
            alert("Customer form fields not found.");
            return;
        }
        const customer = {
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
            const response = yield fetch(`${apiBaseUrl}/Customers`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(customer)
            });
            const responseText = yield response.text();
            console.log("POST /Customers status:", response.status);
            console.log("POST /Customers response:", responseText);
            if (response.ok) {
                alert("Customer added successfully.");
                nameInput.value = "";
                emailInput.value = "";
                phoneInput.value = "";
                yield loadCustomers();
                yield loadDashboard();
                showSection("customerSection");
            }
            else {
                alert(`Failed to add customer. ${responseText}`);
            }
        }
        catch (error) {
            console.error("Error adding customer:", error);
            alert("Error adding customer. Check backend/API.");
        }
    });
}
function submitTicket(event) {
    return __awaiter(this, void 0, void 0, function* () {
        event.preventDefault();
        const customerIdInput = document.getElementById("ticketCustomerId");
        const categoryIdInput = document.getElementById("ticketCategoryId");
        const agentIdInput = document.getElementById("ticketAgentId");
        const statusIdInput = document.getElementById("ticketStatusId");
        const descriptionInput = document.getElementById("ticketDescription");
        if (!customerIdInput ||
            !categoryIdInput ||
            !agentIdInput ||
            !statusIdInput ||
            !descriptionInput) {
            alert("Ticket form fields not found.");
            return;
        }
        const ticket = {
            customerId: parseInt(customerIdInput.value),
            categoryId: parseInt(categoryIdInput.value),
            agentId: parseInt(agentIdInput.value),
            statusId: parseInt(statusIdInput.value),
            description: descriptionInput.value.trim(),
            createdAt: new Date().toISOString(),
            updatedAt: new Date().toISOString(),
            resolutionNotes: ""
        };
        if (isNaN(ticket.customerId) ||
            isNaN(ticket.categoryId) ||
            isNaN(ticket.agentId) ||
            isNaN(ticket.statusId) ||
            !ticket.description) {
            alert("Please fill all ticket fields correctly.");
            return;
        }
        try {
            const response = yield fetch(`${apiBaseUrl}/Tickets`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(ticket)
            });
            const responseText = yield response.text();
            console.log("POST /Tickets status:", response.status);
            console.log("POST /Tickets response:", responseText);
            if (response.ok) {
                alert("Ticket added successfully.");
                customerIdInput.value = "";
                categoryIdInput.value = "";
                agentIdInput.value = "";
                statusIdInput.value = "";
                descriptionInput.value = "";
                yield loadTickets();
                yield loadDashboard();
                showSection("ticketSection");
            }
            else {
                alert(`Failed to add ticket. ${responseText}`);
            }
        }
        catch (error) {
            console.error("Error adding ticket:", error);
            alert("Error adding ticket.");
        }
    });
}
document.addEventListener("DOMContentLoaded", () => __awaiter(this, void 0, void 0, function* () {
    const addCustomerForm = document.getElementById("addCustomerForm");
    const addTicketForm = document.getElementById("addTicketForm");
    if (addCustomerForm) {
        addCustomerForm.addEventListener("submit", submitCustomer);
    }
    else {
        console.error("addCustomerForm not found");
    }
    if (addTicketForm) {
        addTicketForm.addEventListener("submit", submitTicket);
    }
    else {
        console.error("addTicketForm not found");
    }
    showSection("dashboardSection");
    yield loadDashboard();
    yield loadTickets();
    yield loadCustomers();
}));
window.showSection = showSection;
window.updateTicket = updateTicket;
window.submitCustomer = submitCustomer;
window.submitTicket = submitTicket;
window.loadCustomers = loadCustomers;
window.loadTickets = loadTickets;
window.loadDashboard = loadDashboard;
