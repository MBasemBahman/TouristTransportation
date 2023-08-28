function getAreas(elem, fk_Country, removeFirstElem = true) {
    var serviceUrl = "/Dashboard/Services/GetAreasByFilters?fk_Country=" + fk_Country;
    $.ajax({
        type: "Get",
        url: serviceUrl,
        success: function (result) {
            if (removeFirstElem) {
                $(elem).empty();
            }
            else {
                $(elem).find('option').not(':first').remove();
            }
            
            let options = '';
            if (result.length > 0) {
                for (let i = 0; i < result.length; i++) {
                    options += '<option value="' + result[i].id + '">' + result[i].name + '</option>'
                }
            }
            
            $(elem).append(options);
        }
    });
}

function getAccounts(elem, fk_AccountType, removeFirstElem = true) {
    let serviceUrl = "/Dashboard/Services/GetAccountsByFilters?fk_AccountType=" + fk_AccountType;
    
    $.ajax({
        type: "Get",
        url: serviceUrl,
        success: function (result) {
            if (removeFirstElem) {
                $(elem).empty();
            }
            else {
                $(elem).find('option').not(':first').remove();
            }

            let options = '';
            
            result.forEach(account => {
                
                    options += '<option value="' + account.id + '">' + account.user.name + '</option>';
            });

            $(elem).append(options);
        }
    });
}

