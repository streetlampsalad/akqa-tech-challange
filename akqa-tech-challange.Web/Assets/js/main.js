$(document).ready(function () {
    $('#form').submit(function () {
        event.preventDefault();

        var name = $('#name').val();
        var currency = $('#currency').val();

        if (isNaN(currency)) {
            updateResponse("Invalid currency", "", "");                            
            return false;
        }
        
        var data = {
            name: name,
            currency: currency
        }

        $.ajax({
            type: 'POST',
            url: '/api/NumberConverter/CurrencyToWord',
            data: data,
            success: function (data) {
                updateResponse("", data.name, data.currencyConverted);                 
            },
            error: function (data) {                
                updateResponse(data.responseJSON.ExceptionMessage, "", "");                
            },
        });
    });
});

function updateResponse(error, name, currencyConverted) {
    $('.form-response').fadeOut(function () {
        $('.form-response-error').html(error);
        $('.form-response-name').html(name);
        $('.form-response-currency-converted').html(currencyConverted);
    });
    $('.form-response').fadeIn();
}