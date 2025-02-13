from flask import Flask, request, render_template_string

app = Flask(__name__)

# Vulnerable route (XSS)
@app.route('/vulnerable')
def vulnerable():
    # Get user input from the query parameter 'name'
    name = request.args.get('name', 'Guest')
    
    # Disable auto-escaping for this template to demonstrate XSS
    email_template = """
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Offer Letter</title>
        <style>
            body {
                font-family: Arial, sans-serif;
                background-color: #f4f4f4;
                margin: 0;
                padding: 20px;
            }
            .email-container {
                max-width: 600px;
                margin: 0 auto;
                background: #ffffff;
                padding: 20px;
                border-radius: 8px;
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            }
            h1 {
                color: #333;
                text-align: center;
            }
            p {
                color: #555;
                line-height: 1.6;
            }
            .offer-details {
                background: #f9f9f9;
                padding: 15px;
                border-radius: 8px;
                margin-top: 20px;
            }
            .footer {
                text-align: center;
                margin-top: 20px;
                color: #888;
            }
        </style>
    </head>
    <body>
        <div class="email-container">
            <h1>🎉 Congratulations, {{ name | safe }}! 🎉</h1>
            <p>We are thrilled to extend an offer for you to join our team at <strong>Awesome Company</strong>!</p>
            
            <div class="offer-details">
                <h2>Offer Details</h2>
                <p><strong>Position:</strong> Software Engineer</p>
                <p><strong>Start Date:</strong> January 1, 2024</p>
                <p><strong>Salary:</strong> $100,000 per year</p>
                <p><strong>Benefits:</strong> Health insurance, 401(k), and more!</p>
            </div>

            <p>Please review the details and let us know if you have any questions. We look forward to having you on board!</p>

            <div class="footer">
                <p>Best regards,</p>
                <p><strong>The Awesome Company Team</strong></p>
            </div>
        </div>
    </body>
    </html>
    """
    
    # Render the template without escaping the input (vulnerable to XSS)
    return render_template_string(email_template, name=name)

if __name__ == '__main__':
    app.run(debug=True)