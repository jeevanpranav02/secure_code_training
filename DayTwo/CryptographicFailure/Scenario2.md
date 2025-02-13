# **Scenario 2: Secure Patient Data Management**  

## **Objective**  
Allow logged-in admins to securely add and view patient records, ensuring the sensitive information is stored securely.  

## **Features**  

- **Patient Data Input:**  
  - Admins can add patient details, including:  
    - Name  
    - Age  
    - Email  
    - Social Security Number (SSN)  
    - History of Illness  

- **Data Encryption:**  
  - Encrypt patient data using AES (Advanced Encryption Standard) before storage. (u can use Fernet)
  - Secure key management for encryption per admin session.  

- **Secure Data Storage:**  
  - Store encrypted patient records in memory.  

- **Access Control:**  
  - Only logged-in admins can add and view patient data.  

- **Data Decryption:**  
  - Decrypt patient records securely before displaying them.  
