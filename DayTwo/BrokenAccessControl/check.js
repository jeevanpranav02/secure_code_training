app.post('/login', (req, res) => {
    username = req.query.username;
    password = req.query.password;
    
    if is_valid_login(username, password){
        start_session(username);
        redirect('/dashboard', 'Login successful!');
    } else {
        redirect('/login', 'Username  or password incorrect');
    }
})