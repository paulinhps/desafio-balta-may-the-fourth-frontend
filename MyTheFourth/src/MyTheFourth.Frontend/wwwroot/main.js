function toggleTheme() {    
    var theme = document.body.dataset.bsTheme;
    document.body.dataset.bsTheme = theme === "light" ? "dark" : "light";
}