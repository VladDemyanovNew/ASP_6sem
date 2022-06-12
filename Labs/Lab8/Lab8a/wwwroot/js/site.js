function displayErrorMessages(name, phone) {
    if (name.length === 0) {
        name_require_error.classList.remove('hidden');
    } else {
        name_require_error.classList.add('hidden');
    }

    if (phone.length === 0) {
        phone_require_error.classList.remove('hidden');
    } else {
        phone_require_error.classList.add('hidden');
    }

    if (doesPhoneValid(phone)) {
        phone_format_error.classList.add('hidden');
    } else {
        phone_format_error.classList.remove('hidden');
    }
}

function doesFormValid(name, phone) {
    return name.length > 0 && phone.length > 0 && doesPhoneValid(phone);
}

function doesPhoneValid(phone) {
    const regularExp = /^\d[\d\(\)\ -]{4,14}\d$/;
    return regularExp.test(phone);
}