document.addEventListener('DOMContentLoaded', function () {
    // --- Scroll animation cho DANH MỤC SẢN PHẨM ---
    const catLeft = document.querySelectorAll('.cat-animate-left');
    const catUp = document.querySelectorAll('.cat-animate-up');

    const options = {
        threshold: 0.3 
    };

    const observer = new IntersectionObserver((entries, obs) => {
        entries.forEach(entry => {
            if (!entry.isIntersecting) return;

            const el = entry.target;

            if (el.classList.contains('cat-animate-left')) {
                el.classList.add('cat-visible-left');
            }

            if (el.classList.contains('cat-animate-up')) {
                el.classList.add('cat-visible-up');
            }

            obs.unobserve(el);
        });
    }, options);

    [...catLeft, ...catUp].forEach(el => observer.observe(el));
});
