// Admin Layout Main JavaScript
(function() {
    'use strict';

    // Initialize when DOM is ready
    document.addEventListener('DOMContentLoaded', function() {
        initSidebar();
        initThemeToggle();
        initFullscreenToggle();
        initTooltips();
        hideLoadingScreen();
    });

    // Sidebar Toggle
    function initSidebar() {
        const toggleButton = document.querySelector('[data-sidebar-toggle]');
        const wrapper = document.getElementById('admin-wrapper');

        if (toggleButton && wrapper) {
            // Set initial state from localStorage
            const isCollapsed = localStorage.getItem('sidebar-collapsed') === 'true';
            if (isCollapsed) {
                wrapper.classList.add('sidebar-collapsed');
                toggleButton.classList.add('is-active');
            }

            // Attach click listener
            toggleButton.addEventListener('click', function() {
                const isCurrentlyCollapsed = wrapper.classList.contains('sidebar-collapsed');
                
                if (isCurrentlyCollapsed) {
                    wrapper.classList.remove('sidebar-collapsed');
                    toggleButton.classList.remove('is-active');
                    localStorage.setItem('sidebar-collapsed', 'false');
                } else {
                    wrapper.classList.add('sidebar-collapsed');
                    toggleButton.classList.add('is-active');
                    localStorage.setItem('sidebar-collapsed', 'true');
                }
            });
        }
    }

    // Theme Toggle
    function initThemeToggle() {
        const themeToggle = document.getElementById('theme-toggle');
        const themeIcon = document.getElementById('theme-icon');
        
        if (themeToggle) {
            // Get initial theme
            const currentTheme = localStorage.getItem('theme') || 'light';
            document.documentElement.setAttribute('data-bs-theme', currentTheme);
            updateThemeIcon(currentTheme, themeIcon);

            themeToggle.addEventListener('click', function() {
                const currentTheme = document.documentElement.getAttribute('data-bs-theme');
                const newTheme = currentTheme === 'light' ? 'dark' : 'light';
                
                document.documentElement.setAttribute('data-bs-theme', newTheme);
                localStorage.setItem('theme', newTheme);
                updateThemeIcon(newTheme, themeIcon);
            });
        }
    }

    function updateThemeIcon(theme, iconElement) {
        if (iconElement) {
            iconElement.className = theme === 'light' 
                ? 'bi bi-sun-fill' 
                : 'bi bi-moon-fill';
        }
    }

    // Fullscreen Toggle
    function initFullscreenToggle() {
        const fullscreenButton = document.querySelector('[data-fullscreen-toggle]');
        
        if (fullscreenButton) {
            fullscreenButton.addEventListener('click', async function() {
                try {
                    if (!document.fullscreenElement) {
                        await document.documentElement.requestFullscreen();
                    } else {
                        await document.exitFullscreen();
                    }
                } catch (error) {
                    console.error('Fullscreen toggle failed:', error);
                }
            });
        }
    }

    // Initialize Bootstrap Tooltips
    function initTooltips() {
        const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }

    // Hide Loading Screen
    function hideLoadingScreen() {
        const loadingScreen = document.getElementById('loading-screen');
        if (loadingScreen) {
            setTimeout(function() {
                loadingScreen.style.opacity = '0';
                setTimeout(function() {
                    loadingScreen.style.display = 'none';
                }, 300);
            }, 500);
        }
    }

    // Keyboard shortcuts
    document.addEventListener('keydown', function(e) {
        // Ctrl/Cmd + K for search
        if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
            e.preventDefault();
            const searchInput = document.querySelector('[data-search-input]');
            if (searchInput) {
                searchInput.focus();
            }
        }
    });
})();

