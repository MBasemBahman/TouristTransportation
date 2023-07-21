let horizontalWizard = document.querySelector('.horizontal-wizard-example');
let numberedStepper = new Stepper(horizontalWizard);

$(horizontalWizard).find('.btn-prev').on('click', function () {
    numberedStepper.previous();
});

function saveHotel(data, errDiv) {
    $.ajax({
        url: `/HotelEntity/Hotel/CreateOrEditWizard`,
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
            $("input[name=fk_Hotel]").val(data.id);
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

function nextForm(errDiv = $(".post_error_div")) {
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

$(document).on('change', 'select[name=Fk_Country]', function () {
    let fk_Country = $(this).val();
    getAreas($("select[name=Fk_Area]"), fk_Country, false);
});

/////////////////////////////////////////////////////////////
Dropzone.autoDiscover = false;

$(function () {
    'use strict';

    let myDropzone = new Dropzone("#dpz-multiple-files", {
        paramName: 'file', // The name that will be used to transfer the file
        maxFilesize: 10, // MB
        clickable: true,
        addRemoveLinks: true,
        dictRemoveFileConfirmation:  "Are you sure?",
        dictRemoveFile: '<i class="fas fa-trash-alt"></i>',
        removedfile: function (file) {
            $.ajax({
                url: `/HotelEntity/HotelAttachment/Delete`,
                method: "post",
                data: {id: file.id},
                success: function (data) {
                }
            });

            file.previewTemplate.remove();
        }
    });

    let fk_Hotel = $("input[name=fk_Hotel]").val();

    if (fk_Hotel > 0) {
        $.ajax({
            url: `/HotelEntity/HotelAttachment/GetHotelAttachments?fk_Hotel=${fk_Hotel}`,
            method: "get",
            success: function (data) {
                //Add existing files into dropzone
                let filesArr = [];

                data.forEach(existingFile => {
                    filesArr.push({
                        id: existingFile.id,
                        name: existingFile.fileName,
                        size: existingFile.fileLength,
                        fullPath: existingFile.fileUrl,
                        fileType: existingFile.fileType
                    });
                });

                filesArr.forEach(existingFile => {
                    let thumbnail = "";

                    if (existingFile.fileType == "image/jpeg" || existingFile.fileType == "image/png" || existingFile.fileType == "image/jpg") {
                        thumbnail = existingFile.fullPath;
                    } else if (existingFile.fileType == "application/pdf") {
                        thumbnail = "/pdf.png";
                    } else if (existingFile.fileType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || existingFile.fileType == "application/msword") {
                        thumbnail = "/docx.png";
                    } else if (existingFile.fileType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || existingFile.fileType == "application/vnd.ms-excel") {
                        thumbnail = "/sheets.png";
                    } else {
                        thumbnail = "/file.png";
                    }

                    myDropzone.emit("addedfile", existingFile);
                    myDropzone.emit("thumbnail", existingFile, thumbnail);
                    myDropzone.emit("complete", existingFile);
                });
            }
        });
    }

});
/////////////////////////////////////////////////////////////