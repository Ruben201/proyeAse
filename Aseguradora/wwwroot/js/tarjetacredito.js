var $cc = {};

$cc.validate = function (e) {
    function luhn(number) {
        var numberArray = number.split('').reverse();
        for (var i = 0; i < numberArray.length; i++) {
            if (i % 2 !== 0) {
                numberArray[i] = (numberArray[i] * 2 > 9) ?
                    (numberArray[i] * 2 - 9) : (numberArray[i] * 2);
            }
        }
        var sum = numberArray.reduce(function (acc, val) {
            return acc + parseInt(val, 10);
        }, 0);
        return sum % 10 === 0;
    }

    if (e.target.value === '') {
        document.querySelector('.card-type').setAttribute('class', 'card-type');
        e.target.nextElementSibling.className = 'card-valid';
        return;
    }

    var number = e.target.value.replace(/\D/g, '');

    if (e.key !== 'Backspace') {
        var formattedNumber = number.replace(/(\d{4})(?=\d)/g, '$1 ');
        e.target.value = formattedNumber.trim();
    }

    var isLuhn = false;
    if (number.length >= 12) {
        isLuhn = luhn(number);
    }

    e.target.nextElementSibling.className = isLuhn ? 'card-valid active' : 'card-valid';

    var cardTypes = [
        { name: 'amex', pattern: /^3[47]/, valid_length: [15] },
        // ... (otros tipos de tarjetas)
    ];

    for (var cardType of cardTypes) {
        if (number.match(cardType.pattern)) {
            document.querySelector('.card-type').setAttribute('class', 'card-type ' + cardType.name);
            break;
        }
    }
};

$cc.expiry = function (e) {
    if (e.key !== 'Backspace') {
        var number = this.value.replace(/\D/g, '');
        var formattedMonth = number.replace(/(\d{2})(\d{0,4})/, function (match, p1, p2) {
            return (p1 > 12 ? '12' : p1) + (p2 ? '/' + p2 : '');
        });
        this.value = formattedMonth;
    }
};