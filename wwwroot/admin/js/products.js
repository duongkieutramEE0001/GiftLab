// Products JavaScript
(function() {
    'use strict';

    // Initialize when DOM is ready
    document.addEventListener('DOMContentLoaded', function() {
        initEditProductModal();
        initDeleteProductModal();
        initViewProductModal();
        initImagePreview();
        initFilterModal();
    });

    // Edit Product Modal - Load data when opened
    function initEditProductModal() {
        const editProductModal = document.getElementById('editProductModal');
        if (editProductModal) {
            editProductModal.addEventListener('show.bs.modal', function (event) {
                const button = event.relatedTarget;
                const productId = button.getAttribute('data-product-id');
                const productName = button.getAttribute('data-product-name');
                const productCategory = button.getAttribute('data-product-category');
                const productPrice = button.getAttribute('data-product-price');
                const productStock = button.getAttribute('data-product-stock');
                const productStatus = button.getAttribute('data-product-status');
                
                document.getElementById('editProductId').value = productId;
                document.getElementById('editProductName').value = productName;
                document.getElementById('editProductCategory').value = productCategory;
                document.getElementById('editProductPrice').value = productPrice;
                document.getElementById('editProductStock').value = productStock;
                document.getElementById('editProductStatus').value = productStatus;
            });
        }
    }

    // Delete Product Modal - Load data when opened
    function initDeleteProductModal() {
        const deleteProductModal = document.getElementById('deleteProductModal');
        if (deleteProductModal) {
            deleteProductModal.addEventListener('show.bs.modal', function (event) {
                const button = event.relatedTarget;
                const productId = button.getAttribute('data-product-id');
                const productName = button.getAttribute('data-product-name');
                
                document.getElementById('deleteProductId').value = productId;
                document.getElementById('deleteProductName').textContent = productName;
            });
        }
    }

    // Make functions globally available for onclick handlers
    window.handleAddProduct = function() {
        const form = document.getElementById('addProductForm');
        if (form.checkValidity()) {
            // TODO: Implement add product logic
            console.log('Add product:', {
                name: document.getElementById('addProductName').value,
                category: document.getElementById('addProductCategory').value,
                price: document.getElementById('addProductPrice').value,
                stock: document.getElementById('addProductStock').value,
                status: document.getElementById('addProductStatus').value,
                description: document.getElementById('addProductDescription').value
            });
            
            const modal = bootstrap.Modal.getInstance(document.getElementById('addProductModal'));
            modal.hide();
            form.reset();
            alert('Đã thêm sản phẩm thành công!');
        } else {
            form.reportValidity();
        }
    };

    window.handleEditProduct = function() {
        const form = document.getElementById('editProductForm');
        if (form.checkValidity()) {
            const productId = document.getElementById('editProductId').value;
            // TODO: Implement edit product logic
            console.log('Edit product:', {
                id: productId,
                name: document.getElementById('editProductName').value,
                category: document.getElementById('editProductCategory').value,
                price: document.getElementById('editProductPrice').value,
                stock: document.getElementById('editProductStock').value,
                status: document.getElementById('editProductStatus').value,
                description: document.getElementById('editProductDescription').value
            });
            
            const modal = bootstrap.Modal.getInstance(document.getElementById('editProductModal'));
            modal.hide();
            alert('Đã cập nhật sản phẩm thành công!');
        } else {
            form.reportValidity();
        }
    };

    window.handleDeleteProduct = function() {
        const productId = document.getElementById('deleteProductId').value;
        // TODO: Implement delete product logic
        console.log('Delete product:', productId);
        
        const modal = bootstrap.Modal.getInstance(document.getElementById('deleteProductModal'));
        modal.hide();
        alert('Đã xóa sản phẩm thành công!');
    };

    // Preview Image Function
    function initImagePreview() {
        const addProductImage = document.getElementById('addProductImage');
        const editProductImage = document.getElementById('editProductImage');
        
        if (addProductImage) {
            addProductImage.addEventListener('change', function() {
                previewImage(this, 'addProductImagePreview');
            });
        }
        
        if (editProductImage) {
            editProductImage.addEventListener('change', function() {
                previewImage(this, 'editProductImagePreview');
            });
        }
    }

    window.previewImage = function(input, previewId) {
        const preview = document.getElementById(previewId);
        if (input.files && input.files[0]) {
            const reader = new FileReader();
            reader.onload = function(e) {
                preview.src = e.target.result;
                preview.style.display = 'block';
            };
            reader.readAsDataURL(input.files[0]);
        } else {
            if (preview) {
                preview.style.display = 'none';
            }
        }
    };

    // View Product Modal - Load data when opened
    function initViewProductModal() {
        const viewProductModal = document.getElementById('viewProductModal');
        if (viewProductModal) {
            viewProductModal.addEventListener('show.bs.modal', function (event) {
                const button = event.relatedTarget;
                const productId = button.getAttribute('data-product-id');
                const productName = button.getAttribute('data-product-name');
                const productCategory = button.getAttribute('data-product-category');
                const productPrice = button.getAttribute('data-product-price');
                const productStock = button.getAttribute('data-product-stock');
                const productStatus = button.getAttribute('data-product-status');
                const productImage = button.getAttribute('data-product-image');
                const productDescription = button.getAttribute('data-product-description');
                
                document.getElementById('viewProductId').textContent = '#' + productId;
                document.getElementById('viewProductName').textContent = productName;
                document.getElementById('viewProductCategory').textContent = productCategory;
                document.getElementById('viewProductPrice').textContent = '₫' + parseInt(productPrice).toLocaleString('vi-VN');
                document.getElementById('viewProductStock').textContent = productStock;
                document.getElementById('viewProductDescription').textContent = productDescription || 'Chưa có mô tả.';
                
                // Set status badge
                const statusElement = document.getElementById('viewProductStatus');
                if (productStatus === 'In Stock' || productStatus === 'Còn hàng') {
                    statusElement.innerHTML = '<span class="badge bg-success">Còn hàng</span>';
                } else if (productStatus === 'Out of Stock' || productStatus === 'Hết hàng') {
                    statusElement.innerHTML = '<span class="badge bg-danger">Hết hàng</span>';
                } else {
                    statusElement.innerHTML = '<span class="badge bg-warning">Sắp hết hàng</span>';
                }
                
                // Set image
                document.getElementById('viewProductImage').src = productImage;
                
                // Set edit button to open edit modal
                const editFromViewBtn = document.getElementById('editFromViewBtn');
                if (editFromViewBtn) {
                    editFromViewBtn.onclick = function() {
                        const modal = bootstrap.Modal.getInstance(viewProductModal);
                        modal.hide();
                        // Trigger edit modal with same data
                        setTimeout(() => {
                            button.click();
                        }, 300);
                    };
                }
            });
        }
    }

    // Filter Modal
    function initFilterModal() {
        const clearFiltersBtn = document.getElementById('clearProductFiltersBtn');
        const applyFiltersBtn = document.getElementById('applyProductFiltersBtn');
        
        if (clearFiltersBtn) {
            clearFiltersBtn.addEventListener('click', clearProductFilters);
        }
        
        if (applyFiltersBtn) {
            applyFiltersBtn.addEventListener('click', applyProductFilters);
        }
    }

    window.applyProductFilters = function() {
        const category = document.getElementById('filterProductCategory').value;
        const status = document.getElementById('filterProductStatus').value;
        const priceFrom = document.getElementById('filterProductPriceFrom').value;
        const priceTo = document.getElementById('filterProductPriceTo').value;
        const stockFrom = document.getElementById('filterProductStockFrom').value;
        const stockTo = document.getElementById('filterProductStockTo').value;
        
        // TODO: Apply filters
        console.log('Apply product filters:', { category, status, priceFrom, priceTo, stockFrom, stockTo });
        
        const modal = bootstrap.Modal.getInstance(document.getElementById('filterProductModal'));
        modal.hide();
    };

    window.clearProductFilters = function() {
        document.getElementById('filterProductCategory').value = '';
        document.getElementById('filterProductStatus').value = '';
        document.getElementById('filterProductPriceFrom').value = '';
        document.getElementById('filterProductPriceTo').value = '';
        document.getElementById('filterProductStockFrom').value = '';
        document.getElementById('filterProductStockTo').value = '';
    };
})();

