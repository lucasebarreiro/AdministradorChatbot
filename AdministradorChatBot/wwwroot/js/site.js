function togglePassword(passwordId, toggleId) {
    const toggle = document.getElementById(toggleId);
    toggle?.addEventListener('click', () => {
        const input = document.getElementById(passwordId);
        if (!input) return;

        input.type = input.type === 'password' ? 'text' : 'password';
        toggle.classList.toggle('fa-eye', input.type === 'text');
        toggle.classList.toggle('fa-eye-slash', input.type === 'password');
    });
}

document.addEventListener('DOMContentLoaded', () => {
    togglePassword('passwordInput', 'togglePassword');
    togglePassword('registerPassword', 'toggleRegisterPassword');
});