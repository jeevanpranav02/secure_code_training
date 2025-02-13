# **Scenario 4: Digital Signing for Medical Reports**  

## **Objective**  
Allow doctors to digitally sign medical reports to ensure authenticity. Recipients, such as hospitals or insurance companies, can verify the signature using the doctor's public key.  

## **Steps**  


1. **Hash the Medical Report:**  
   - Use a secure hashing algorithm like SHA256 to generate a hash of the medical report.  

2. **Sign the Hash:**  
   - Sign the hash using the doctor's private key to create the digital signature.  

3. **Verification:**  
   - The recipient verifies the authenticity of the report by checking the signature using the doctor's public key.  
   - please add Verification feature in the hospital app.





