# **Scenario 1: Shell-Based Registration and Login System (Secure Passcode Handling)**  

## **Objective**  
Develop a simple console app that allows hospital admins to register and log in securely without storing plain-text passcodes.  

## **Features**  

- **Secure Passcode Hashing:**  
  - Use `bcrypt` to securely hash admin passcodes.  

- **Admin Registration:**  
  - Prompt the admin to enter a username and passcode.  
  - Hash the passcode using `bcrypt` and securely store the hash in a file.  

- **Login Mechanism:**  
  - Validate the username and passcode by comparing the hash.  
  - Provide access to patient management functions only upon successful login.  

- **Patient Management Access:**  
  - Only logged-in admins can access and perform patient management functions, such as adding and viewing patient data.
  - Lock out the user after 3 or more failed login attempts with an appropriate message 
