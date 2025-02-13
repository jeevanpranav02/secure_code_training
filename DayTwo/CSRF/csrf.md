
# **Cross-Site Request Forgery (CSRF) Vulnerability: A Detailed Explanation**

## **What is CSRF?**
Cross-Site Request Forgery (CSRF) is a web security vulnerability where an attacker tricks a victim's browser into making unintended requests to a trusted website where the victim is already authenticated. This attack exploits the trust that a website has in the user's browser.

---

## **How CSRF Works (Step-by-Step)**  

### **Step 1: Victim Authenticates on a Trusted Website**
- The user logs into a website (e.g., a bank site) using their valid credentials.  
- The server sets a session cookie to keep the user logged in.

### **Step 2: Victim Visits a Malicious Website**
- The attacker lures the victim to visit a malicious website or clicks on a malicious link embedded in an email.

### **Step 3: Malicious Request is Triggered**
- The malicious website contains hidden code (like a form or JavaScript) that makes a request to the trusted website on behalf of the user.

#### **Example:**  
An attacker embeds a hidden form that automatically submits when the victim visits the page:
```html
<form action="https://bank.example.com/transfer" method="POST">
    <input type="hidden" name="account" value="attacker_account">
    <input type="hidden" name="amount" value="1000">
</form>
<script>document.forms[0].submit();</script>
```

### **Step 4: Server Processes the Request**
- The server assumes the request is legitimate since it is accompanied by the victim's valid session cookie.  
- Funds are transferred or sensitive data is altered without the victim's knowledge.

---

## **Why CSRF Happens**
- The server relies solely on cookies for authentication without additional verification.  
- Browsers automatically include cookies for requests made to the same domain.

---

## **Real-World Example**
Imagine a victim logged into a social media platform. They click a malicious link that makes a request like:
```
POST https://socialmedia.example.com/updateProfile
Body: {"status": "I love malicious hackers"}
```
This request is processed as if it were a legitimate action by the victim.

---

## **Mitigation Techniques**  

### **1. CSRF Tokens**
- Generate a unique token for each user session and require it in every sensitive request.
- Example:
  - Server generates and sends a token: `csrf_token = 12345abcde`
  - The client includes this token in the request:
    ```html
    <input type="hidden" name="csrf_token" value="12345abcde">
    ```

### **2. SameSite Cookies**
- Set the `SameSite` attribute for cookies to `Strict` or `Lax` to prevent them from being sent with cross-origin requests:
  ```http
  Set-Cookie: sessionId=abc123; SameSite=Strict
  ```

### **3. User Authentication Headers**
- Use custom headers like `X-Requested-With`, which are not automatically set by cross-origin requests.

### **4. Verify Referrer Header**
- Check the `Referer` header to ensure the request originates from a trusted domain.

### **5. Secure CORS Policies**
- Restrict cross-origin requests by configuring proper CORS policies.

---

## **Illustration of a Secure Implementation (Django Example)**  

```html
<form method="POST" action="/transfer">
  {% csrf_token %}
  <input type="text" name="account">
  <input type="number" name="amount">
  <button type="submit">Transfer</button>
</form>
```

The server checks the token for validity before processing the request, effectively mitigating CSRF.

---

## **Conclusion**
CSRF is a serious vulnerability that exploits the trust between the user and the website. Implementing defense mechanisms like CSRF tokens and secure cookie attributes is essential to protect web applications from this attack.

