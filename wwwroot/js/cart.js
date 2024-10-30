$(document).ready(function () {
    $(document).on('click', '.btn-add-to-cart', function (e) {
        e.preventDefault();
        var carId = $(this).data('id');
        var notificationContainer = $(this).closest('.col-lg-4').find('.notification-container');

        $.ajax({
            url: '/ShopCart/AddToCart',
            type: 'POST',
            data: { id: carId },
            success: function (result) {
                $('#cart-container').html(result);

                showNotificationAdd(notificationContainer, 'Товар добавлен в корзину!');
            },
            error: function () {
                alert('Ошибка при добавлении товара в корзину.');
            }
        });
    });

    $(document).on('click', '.btn-remove-from-cart', function (e) {
        e.preventDefault();
        var carId = $(this).data('id');

        var mouseX = e.pageX + (e.pageX * 1.1);
        var mouseY = e.pageY - (e.pageX * 0.25);       

        $.ajax({
            url: '/ShopCart/RemoveFromCart',
            type: 'POST',
            data: { id: carId },
            success: function (result) {
                $('#cart-container').html(result);

                if ($('#cart-container').find('.cart-item').length === 0) {
                    // Если корзина пуста, скрываем кнопку "Оплатить"
                    $('#checkout-button-container').hide();
                } else {
                    // Если товары остались, показываем кнопку
                    $('#checkout-button-container').show();
                }

                showNotificationDel(mouseX, mouseY, 'Товар удален из корзины.');
            },
            error: function () {
                alert('Ошибка при удалении товара из корзины.');
            }
        });
    });

    function showNotificationDel(mouseX, mouseY, message) {
        var notification = $(`<div class="alert alert-success custom-notification alert-dismissible fade show" 
                              role="alert"
                              style="position: absolute; top: ${mouseY}px; left: ${mouseX}px; font-style: italic; z-index: 9999;">
                            ${message}
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>`);

        $('body').append(notification);

        setTimeout(function () {
            notification.fadeOut(500, function () {
                $(this).remove(); // Удаляем элемент из DOM
            });
        }, 1000);
    }

    function showNotificationAdd(container, message) {
        container.html(`<div class="alert alert-success custom-notification alert-dismissible fade show"
                        role="alert">
                            ${message}
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>`);
        container.show(); 
        setTimeout(function () {
            container.fadeOut(500); 
        }, 1000);
    }
});
