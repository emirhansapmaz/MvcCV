// Modern CV Page Micro-interactions and Scrollspy
document.addEventListener('DOMContentLoaded', () => {
    // Mobile Navbar Toggle
    const toggler = document.querySelector('.navbar-toggler');
    const navCollapse = document.querySelector('#navbarResponsive');
    const navLinks = document.querySelectorAll('#sideNav .nav-link');

    if (toggler && navCollapse) {
        toggler.addEventListener('click', () => {
            navCollapse.classList.toggle('show');
            const isExpanded = navCollapse.classList.contains('show');
            toggler.setAttribute('aria-expanded', isExpanded);
        });

        // Close mobile menu on link click
        navLinks.forEach(link => {
            link.addEventListener('click', () => {
                if (window.innerWidth < 992 && navCollapse.classList.contains('show')) {
                    navCollapse.classList.remove('show');
                    toggler.setAttribute('aria-expanded', 'false');
                }
            });
        });
    }

    // Scrollspy with Intersection Observer for accurate active highlighting
    const sections = document.querySelectorAll('section[id]');
    
    const observerOptions = {
        root: null,
        rootMargin: '-20% 0px -60% 0px',
        threshold: 0
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const currentId = entry.target.getAttribute('id');
                navLinks.forEach(link => {
                    const href = link.getAttribute('href');
                    if (href === `#${currentId}`) {
                        link.classList.add('active');
                    } else {
                        link.classList.remove('active');
                    }
                });
            }
        });
    }, observerOptions);

    sections.forEach(sec => observer.observe(sec));
});
