# **OWASP Broken Access Control (BAC)**

## **What is Broken Access Control?**
**Broken Access Control** refers to a security vulnerability where an application fails to properly enforce restrictions on what authenticated or unauthenticated users are allowed to do. Attackers exploit this to access unauthorized resources, modify data, or escalate their privileges.

---

## **Why is it Critical?**
- BAC is one of the most common and dangerous vulnerabilities.
- It can lead to data breaches, unauthorized account control, and manipulation of critical resources.

---

## **Types of Broken Access Control**

### 1. **Horizontal Privilege Escalation**
- **Description:** A user accesses data or resources assigned to other users at the same privilege level.
- **Example:** A normal user accessing another user's purchase history by modifying a URL (`/user/123/orders` to `/user/456/orders`).

---

### 2. **Vertical Privilege Escalation**
- **Description:** A lower-privileged user gains access to functions or resources meant for higher-privileged users.
- **Example:** A regular user gaining admin rights by accessing hidden admin panels (`/admin/dashboard`).

---

### 3. **Insecure Direct Object References (IDOR)**
- **Description:** The application exposes internal objects like database keys, allowing users to directly manipulate them.
- **Example:** `/download?file=1234.pdf` can be changed to `/download?file=5678.pdf` to access someone else's document.

---

### 4. **Forced Browsing**
- **Description:** Accessing unprotected endpoints by guessing URLs or manipulating requests.
- **Example:** Accessing `/admin/config` without authentication.

---

### 5. **CORS Misconfiguration**
- **Description:** Cross-Origin Resource Sharing (CORS) settings are overly permissive, allowing unauthorized external domains to access sensitive resources.
- **Example:** Allowing `*` in CORS headers without restriction.

---

### 6. **Missing Function-Level Access Control**
- **Description:** Application functions lack proper checks for user roles.
- **Example:** A regular user can access `/api/deleteUser/123` even though the function is meant only for administrators.

---

### 7. **Path Traversal**
- **Description:** Manipulating URLs to access restricted files outside the intended directory.
- **Example:** Accessing `/etc/passwd` by injecting `../../../etc/passwd` into the file path.

---

### 8. **Access Control via Client-Side Checks**
- **Description:** Relies solely on front-end validation to enforce access control.
- **Example:** Disabling UI elements for restricted actions, but not enforcing the same restrictions server-side.

---

## **Preventive Measures**
- Implement server-side authorization checks for every request.
- Enforce role-based access control (RBAC) and principle of least privilege.
- Use secure session management.
- Regularly test for access control vulnerabilities.
- Ensure sensitive data cannot be accessed or manipulated through IDORs.
- Avoid exposing internal resource references directly.

---


