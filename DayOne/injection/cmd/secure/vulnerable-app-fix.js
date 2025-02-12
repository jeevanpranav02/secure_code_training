const express = require('express');
const { execFile } = require('child_process');

const app = express();
app.use(express.urlencoded({ extended: true }));

// Home Route - Displays the Form
app.get('/', (req, res) => {
    res.send(`
        <h1>Ping a Website</h1>
        <form method="POST" action="/ping">
            <label for="host">Enter a hostname or IP address:</label>
            <input type="text" id="host" name="host" placeholder="e.g., google.com">
            <button type="submit">Ping</button>
        </form>
    `);
});

// Secure Ping Route
app.post('/ping', (req, res) => {
    const host = req.body.host.trim();

    // ✅ Validate input (allow only valid domain names or IPs)
    if (!/^[a-zA-Z0-9.-]+$/.test(host)) {
        return res.status(400).send("❌ Invalid hostname.");
    }

    // ✅ Use `execFile()` (no shell, no command injection)
    execFile('ping', ['-c', '4', host], (error, stdout, stderr) => {
        if (error) {
            return res.status(500).send(`❌ Ping failed: ${stderr}`);
        }
        res.send(`<pre>${stdout}</pre>`);
    });
});

// Start Server
app.listen(3000, () => {
    console.log('✅ Secure ping app running on http://localhost:3000');
});
