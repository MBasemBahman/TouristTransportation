// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getBranches(elem, fk_Company, removeFirstelem = true) {
    var serviceUrl = "/Dashboard/Services/GetBranches?fk_Company=" + fk_Company;
    $.ajax({
        type: "Get",
        url: serviceUrl,
        success: function (result) {
            var selectedValue = $(elem).val();

            if (removeFirstelem) {
                $(elem).empty();
            }
            else {
                $(elem).find('option').not(':first').remove();
            }
            var options = '';
            if (result.length > 0) {
                for (var i = 0; i < result.length; i++) {
                    if (selectedValue == result[i].id) {
                        options += '<option value="' + result[i].id + '" selected>' + result[i].name + '</option>'
                    }
                    else {
                        options += '<option value="' + result[i].id + '">' + result[i].name + '</option>'

                    }
                }
            }
            $(elem).append(options);
        }
    });
}