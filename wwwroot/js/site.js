document.addEventListener('DOMContentLoaded', function () {
    const options = { threshold: 0.2 };

    function makeObserver(selector, visibleClass) {
        const elements = document.querySelectorAll(selector);
        if (!elements.length) return;

        const observer = new IntersectionObserver((entries, obs) => {
            entries.forEach(entry => {
                if (!entry.isIntersecting) return;

                entry.target.classList.add(visibleClass);
                obs.unobserve(entry.target); // chỉ chạy 1 lần
            });
        }, options);

        elements.forEach(el => observer.observe(el));
    }

    // DANH MỤC SẢN PHẨM
    makeObserver('.cat-animate-left', 'cat-visible-left');
    makeObserver('.cat-animate-up', 'cat-visible-up');

    // NEWEST ARRIVAL
    makeObserver('.arr-animate-left', 'arr-visible-left');
    makeObserver('.arr-animate-right', 'arr-visible-right');
});
