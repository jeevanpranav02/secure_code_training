Implementing **Role-Based Access Control (RBAC)** for an API that accesses, modifies, and deletes patient radiology reports is critical to ensure data security, privacy, and compliance with regulations like HIPAA or GDPR. Below is a detailed breakdown of roles, permissions, and how to structure the API to enforce RBAC.

---

### **Roles and Permissions**

1. **Radiologist**
   - **Permissions:**
     - **Read:** Access and view radiology reports.
     - **Create:** Upload new radiology reports.
     - **Update:** Modify existing radiology reports (e.g., add annotations, corrections).
     - **Delete:** Delete radiology reports (with restrictions, e.g., only if no associated treatment exists).
   - **Description:**
     - Radiologists are responsible for creating, interpreting, and updating radiology reports. They need full access to radiology data but may have restrictions on deletion to maintain data integrity.

2. **Physician (Referring Doctor)**
   - **Permissions:**
     - **Read:** Access and view radiology reports for their patients.
     - **Update:** Add comments or notes to radiology reports (but not modify the original report).
     - **Cannot:** Create or delete radiology reports.
   - **Description:**
     - Physicians need access to radiology reports to make informed treatment decisions. They can add comments but cannot alter the original report or delete it.

3. **Lab Technician**
   - **Permissions:**
     - **Read:** Access radiology reports (limited to specific fields, e.g., imaging metadata).
     - **Update:** Update imaging metadata (e.g., scan parameters, timestamps).
     - **Cannot:** Create or delete radiology reports.
   - **Description:**
     - Lab technicians manage imaging equipment and metadata. They have limited access to radiology reports and cannot create or delete them.

4. **Administrator**
   - **Permissions:**
     - **Read:** Access all radiology reports.
     - **Create:** Upload radiology reports (in rare cases, e.g., manual uploads).
     - **Update:** Modify any radiology report.
     - **Delete:** Delete any radiology report.
   - **Description:**
     - Administrators have full access to manage radiology reports, including creating, updating, and deleting them. They are responsible for system maintenance and data integrity.

5. **Patient**
   - **Permissions:**
     - **Read:** Access their own radiology reports.
     - **Cannot:** Create, update, or delete radiology reports.
   - **Description:**
     - Patients can view their own radiology reports but cannot modify or delete them.

6. **Billing Staff**
   - **Permissions:**
     - **Read:** Access radiology reports (limited to billing-related information, e.g., procedure codes).
     - **Cannot:** Create, update, or delete radiology reports.
   - **Description:**
     - Billing staff need access to radiology reports for billing and insurance purposes but have no permissions to modify or delete them.

---

### **API Endpoint Design with RBAC**

Below is an example of how to design API endpoints to enforce RBAC for radiology reports:

#### **1. Get Radiology Report**
- **Endpoint:** `GET /api/radiology-reports/{reportId}`
- **Permissions:**
  - Radiologist, Physician, Lab Technician, Administrator, Patient (only their own reports), Billing Staff.
- **Logic:**
  - Check the user's role and ensure they have access to the requested report.
  - Patients can only access their own reports.

#### **2. Create Radiology Report**
- **Endpoint:** `POST /api/radiology-reports`
- **Permissions:**
  - Radiologist, Administrator.
- **Logic:**
  - Only radiologists and administrators can create new radiology reports.

#### **3. Update Radiology Report**
- **Endpoint:** `PUT /api/radiology-reports/{reportId}`
- **Permissions:**
  - Radiologist (full update), Physician (add comments only), Lab Technician (update metadata only), Administrator.
- **Logic:**
  - Radiologists and administrators can update any field.
  - Physicians can only add comments.
  - Lab technicians can only update metadata.

#### **4. Delete Radiology Report**
- **Endpoint:** `DELETE /api/radiology-reports/{reportId}`
- **Permissions:**
  - Radiologist (with restrictions), Administrator.
- **Logic:**
  - Radiologists can only delete reports if no associated treatment exists.
  - Administrators can delete any report.

#### **5. List Radiology Reports**
- **Endpoint:** `GET /api/radiology-reports`
- **Permissions:**
  - Radiologist, Physician (only their patients), Administrator, Patient (only their own reports), Billing Staff.
- **Logic:**
  - Filter results based on the user's role and permissions.

---

# Step 1: Define Roles and Permissions
roles = {
    "Admin": ["create", "read", "update", "delete"],
    "Editor": ["create", "read", "update"],
    "Viewer": ["read"]
}

# Step 2: Create User-Role Mapping
users = {
    "User1": "Admin",
    "User2": "Editor",
    "User3": "Viewer"
}


# Step 3: Implement Access Control Logic
function hasPermission(user, action):
    role = users[user]  # Get the user's role
    if role in roles:
        if action in roles[role]:  # Check if the role has the required permission
            return True
    return False

