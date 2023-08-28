let horizontalWizard = document.querySelector('.horizontal-wizard-example');
let numberedStepper = new Stepper(horizontalWizard);

$(horizontalWizard).find('.btn-prev').on('click', function () {
    numberedStepper.previous();
});

function saveTrip(data, errDiv) {
    $.ajax({
        url: `/TripEntity/Trip/CreateOrEditWizard`,
        method: 'post',
        data: data,
        cache: false,
        contentType: false,
        processData: false,
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function (data) {
            $("input[name=id]").val(data.id);
            $("input[name=fk_Trip]").val(data.id);
            nextForm(errDiv);
        },
        error: function (errorMessages) {
            
            let errors = '<ul>';
            
            errorMessages.responseJSON.forEach(function (message) {
                errors += `<li>${message}</li>`;
            });
            
            errors += '</ul>';
            
            errDiv.html(errors);
        }
    });
}

function nextForm(errDiv = $(".trip_error_div")) {
    errDiv.html('');
    numberedStepper.next();
}

$(document).on('click', '.modalbtn', function () {
    event.preventDefault();
    var href = $(this).attr('href');
    $('.form-content').load(href);
    $("#Modal").modal("show");
});

$('body').on('click', '.xl-modalbtn', function () {
    event.preventDefault();
    var href = $(this).attr('href');
    $('.form-content').load(href);
    $("#ModalXl").modal("show");
});