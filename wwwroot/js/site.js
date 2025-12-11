// ================== ANIMATION CHO CATEGORY + ARRIVAL ==================
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

    // COLLECTION SLIDER
    initCollectionSlider();
});

// ================= SLIDER COLLECTION - INFINITE LOOP =================
document.addEventListener('DOMContentLoaded', function () {
    const slider = document.querySelector('.collection-slider');
    if (!slider) return;

    const track = slider.querySelector('.col-track');
    const slides = slider.querySelectorAll('.col-slide');
    const btnPrev = slider.querySelector('.col-prev');
    const btnNext = slider.querySelector('.col-next');

    const visibleSlides = 4;
    const totalSlides = slides.length;

    // Clone slide để tạo vòng lặp
    for (let i = 0; i < visibleSlides; i++) {
        const clone = slides[i].cloneNode(true);
        track.appendChild(clone);
    }

    let index = 0;
    let autoplayId = null;
    let isTransitioning = false;

    function updateSlider(withTransition = true) {
        if (withTransition) {
            track.style.transition = "transform 0.5s ease";
        } else {
            track.style.transition = "none";
        }

        const translatePercent = -(100 / visibleSlides) * index;
        track.style.transform = `translateX(${translatePercent}%)`;
    }

    function nextSlide() {
        if (isTransitioning) return;
        isTransitioning = true;

        index++;
        updateSlider(true);

        // Khi chạy đến clone → nhảy về thật mà không bị giật
        if (index === totalSlides) {
            setTimeout(() => {
                index = 0;
                updateSlider(false);
            }, 510);
        }

        setTimeout(() => isTransitioning = false, 520);
    }

    function prevSlide() {
        if (isTransitioning) return;
        isTransitioning = true;

        if (index === 0) {
            index = totalSlides;
            updateSlider(false);
        }

        setTimeout(() => {
            index--;
            updateSlider(true);
        }, 20);

        setTimeout(() => isTransitioning = false, 520);
    }

    btnNext.addEventListener('click', () => {
        nextSlide();
        resetAutoplay();
    });

    btnPrev.addEventListener('click', () => {
        prevSlide();
        resetAutoplay();
    });

    function startAutoplay() {
        autoplayId = setInterval(nextSlide, 2000);
    }

    function resetAutoplay() {
        clearInterval(autoplayId);
        startAutoplay();
    }

    slider.addEventListener('mouseenter', () => clearInterval(autoplayId));
    slider.addEventListener('mouseleave', startAutoplay);

    updateSlider(false);
    startAutoplay();
});
