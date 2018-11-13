$(document).ready(function () {
    $('#form').submit(function () {
        event.preventDefault();

        var name = $('#name').val();
        // Regex removes all special characters
        var currency = $('#currency').val().replace(/[&\/\\#,+()$~%'":*?<>{}]/g, '');
        console.log(currency);

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

// Simple function that refreshes the response details
function updateResponse(error, name, currencyConverted) {
    $('.form-response').fadeOut(function () {
        $('.form-response-error').html(error);
        $('.form-response-name').html(name);
        $('.form-response-currency-converted').html(currencyConverted);
    });
    $('.form-response').fadeIn();
}