'use strict';
$(function () {
    
    // initialize trip_point wizard
    function LoadTable() {
        let dt_ajax_table = $('.trip-points-datatables');
        
        if (dt_ajax_table.length) {
            let dt_ajax = dt_ajax_table.dataTable({
                "scrollX": true,
                stateSave: true,
                autoWidth: true,
                // ServerSide Setups
                processing: true,
                serverSide: true,
                // Paging Setups
                paging: true,
                // Searching Setups
                searching: { regex: true },
                // Column Definitions
                columnDefs: [
                    { targets: "no-sort", orderable: false },
                    { targets: "no-search", searchable: false },
                    {
                        targets: "trim",
                        render: function (data, type, full, meta) {
                            if (type === "display" && data != null) {
                                data = strtrunc(data, 15);
                            }
                            return data;
                        }
                    },
                    {
                        // Actions
                        targets: -1,
                        title: feather.icons['settings'].toSvg({ class: 'me-50 font-small-4' }) + $("#ActionsLbl").val(),
                        orderable: false,
                        render: function (data, type, full, meta) {
                            var actions = '<div class="d-inline-flex">' +
                                '<a class="pe-1 dropdown-toggle hide-arrow text-warning" data-bs-toggle="dropdown">' +
                                feather.icons['more-vertical'].toSvg({ class: 'font-small-4' }) +
                                '</a>' +
                                '<div class="dropdown-menu dropdown-menu-end">';

                            if ($('#details-trip-point').attr('href') != undefined) {
                                actions += '<a href="' + $('#details-trip-point').attr('href') + "/" + full.id + '" class="dropdown-item modalbtn">' +
                                    feather.icons['file-text'].toSvg({ class: 'font-small-4 me-50' }) +
                                    '' + $("#DetailsLbl").val() + '</a>';
                            }

                            if ($('#delete-trip-point').attr('href') != undefined) {
                                actions += '<a href="' + $('#delete-trip-point').attr('href') + "/" + full.id + '" class="dropdown-item remove_trip_point">' +
                                    feather.icons['trash-2'].toSvg({ class: 'font-small-4 me-50' }) +
                                    '' + $("#RemoveLbl").val() + '</a>';
                            }

                            actions += '</div>' +
                                '</div>';

                            if ($('#edit-trip-point').attr('href') != undefined) {
                                actions += '<a href="' + $('#edit-trip-point').attr('href') + "/" + full.id + '" target="_blank" data-id="'+full.id+'" class="item-edit edit-trip-point-elem">' +
                                    feather.icons['edit'].toSvg({ class: 'font-small-4' }) +
                                    '</a>';
                            }

                            return (actions);
                        }
                    }
                ],
                dom: '<"card-header p-1"<"head-label"><"dt-action-buttons text-end"B>><"d-flex justify-content-between align-items-center mx-0 row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>t<"d-flex justify-content-between mx-0 row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',
                displayLength: 7,
                lengthMenu: [7, 10, 25, 50, 75, 100, 1000],
                buttons: [
                    {
                        extend: 'collection',
                        className: 'btn btn-outline-secondary dropdown-toggle me-2',
                        text: feather.icons['share'].toSvg({ class: 'font-small-4 me-50' }) + $("#ExportLbl").val(),
                        buttons: function () {
                            let table_btns = [
                                {
                                    extend: 'print',
                                    text: feather.icons['printer'].toSvg({ class: 'font-small-4 me-50' }) + $("#PrintLbl").val(),
                                    className: 'dropdown-item'
                                },
                                {
                                    extend: 'csv',
                                    text: feather.icons['file-text'].toSvg({ class: 'font-small-4 me-50' }) + $("#CsvLbl").val(),
                                    className: 'dropdown-item'
                                },
                                {
                                    extend: 'copy',
                                    text: feather.icons['copy'].toSvg({ class: 'font-small-4 me-50' }) + $("#CopyLbl").val(),
                                    className: 'dropdown-item'
                                },
                            ];

                            if ( $('#export').attr('href') != undefined ) {
                                table_btns.push({
                                    extend: 'excel',
                                    text: feather.icons['file'].toSvg({ class: 'font-small-4 me-50' }) + $("#ExcelLbl").val(),
                                    className: 'dropdown-item'
                                });
                            }

                            return table_btns;
                        },
                        init: function (api, node, config) {
                            $(node).removeClass('btn-secondary');
                            $(node).parent().removeClass('btn-group');
                            setTimeout(function () {
                                $(node).closest('.dt-buttons').removeClass('btn-group').addClass('d-inline-flex');
                            }, 50);
                        }
                    },
                    {
                        text: feather.icons['plus'].toSvg({ class: 'me-50 font-small-4' }) + $("#AddNewLbl").val(),
                        className: 'create-new btn btn-primary',
                        init: function (api, node, config) {
                            if ($('#create').attr('href') == undefined) {
                                $(node).hide();
                            } else {
                                $(node).removeClass('btn-secondary');
                            }
                        },
                        action: function (e, dt, button, config) {
                            window.location = $('#create').attr('href');
                        }
                    },
                    {
                        text: feather.icons['plus'].toSvg({ class: 'me-50 font-small-4' }) + $("#AddNewLbl").val(),
                        className: 'create-new btn btn-primary',
                        init: function (api, node, config) {
                            if ($('#createModal').attr('href') == undefined) {
                                $(node).hide();
                            } else {
                                $(node).removeClass('btn-secondary');
                            }
                        },
                        action: function () {
                            var href = $("#createModal").attr('href');
                            $('.form-content').load(href);
                            $("#Modal").modal("show");
                        }
                    }
                ],
                language: {
                    paginate: {
                        // remove previous & next text from pagination
                        previous: '&nbsp;',
                        next: '&nbsp;'
                    },
                    "search": $("#SearchLbl").val(),
                    "sLengthMenu": $("#DispalyLbl").val() + "_MENU_" + $("#EntitiesLbl").val(),
                },
                // Ajax Filter
                ajax: {
                    url: '/TripEntity/TripPoint/LoadTable',
                    type: "POST",
                    contentType: "application/json",
                    dataType: "json",
                    data: function (data) {
                        data.Fk_Trip = $("#id").length > 0 ? $("#id").val() : 0;

                        return JSON.stringify(data);
                    }
                },
                // Columns Setups
                columns: [
                    { data: "id" },
                    { data: "price" },
                    { data: "waitingTime" },
                    { data: "tripAt" },
                    { data: "leaveAt" },
                    { data: "fromAddress" },
                    { data: "toAddress" },
                    { data: "id" },
                ]
            });
        }
    }

    $(document).ready(function () {
        LoadTable();

        $(".displayType").on('click', function () {
            let dataTable = $("#trip-points-ajax-datatable");
            if (dataTable.css('display') != 'none') {
                dataTable.css('display', 'none');
            }
        });
        
        $(document).on("click", ".remove_trip_point", function (e) {
            e.preventDefault();
            
            let url = $(this).attr('href');
            let that = $(this);
            
            if (confirm('Are you sure ?')) {
                $.ajax({
                    url: url,
                    method: 'post',
                    success: function (data) {
                        that.parent().closest('tr').remove();
                    }
                });
            }
        });
       
        $(document).on('click', '.add_trip_point_btn', function () {
            
        });
    });

    // create or edit modals
    $(document).on('click', '.add_trip_point_btn', function () {
        resetTripPointForm();
    });

    $(document).on('click', '.edit-trip-point-elem', function (e) {
        e.preventDefault();

        let id = $(this).data('id');

        $.ajax({
            url : `/Dashboard/Services/GetTripPointById`,
            method: 'post',
            data: {id: id},
            beforeSend: function () {
                $('#cover-spin').show();
            },
            complete: function () {
                $('#cover-spin').hide();
            },
            success: function (data) {
                $('#add-new-trip-point-modal').modal('show');

                setTripPointFormForEdit(data);
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    $(document).on('click', '.submit_trip_point_modal', function (e) {
        e.preventDefault();

        let tripPointForm = $('.trip_point_form')[0];
        let tripPointFormData = prepareTripPointForm(new FormData(tripPointForm));
        tripPointFormData.append('fk_Trip', $("#id").length > 0 ? $("#id").val() : 0);

        $.ajax({
            url: `/TripEntity/TripPoint/CreateOrEditWizard`,
            method: 'post',
            data: tripPointFormData,
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
                resetTripPointForm();

                $('.trip-points-datatables').DataTable().draw();

                $('#add-new-trip-point-modal').modal('hide');

                $('.trip_point_error_div').html('');
            },
            error: function (errorMessages) {

                let errors = '<ul>';

                errorMessages.responseJSON.forEach(function (message) {
                    errors += `<li>${message}</li>`;
                });

                errors += '</ul>';

                $('.trip_point_error_div').html(errors);
            }
        });
    });

    function resetTripPointForm() {
        $("input[name=trip_point_id]").val("0");
        
        $("input[name=trip_point_from_latitude]").val("0");
        $("input[name=trip_point_from_longitude]").val("0");
        
        $("input[name=trip_point_to_latitude]").val("0");
        $("input[name=trip_point_to_longitude]").val("0");
        
        $("input[name=trip_point_price]").val("");
        $("input[name=trip_point_trip_at]").val("");
        $("input[name=trip_point_leave_at]").val("");
        
        $("input[name=trip_point_waiting_time]").val("");
        
        $("input[name=trip_point_from_address]").val("");
        $("input[name=trip_point_to_address]").val("");

        $('.trip_point_error_div').html('');
    }

    function setTripPointFormForEdit(data) {

        $('input[name=trip_point_id]').val(data.id);
        
        $('input[name=trip_point_from_latitude]').val(data.fromLatitude).trigger('input');
        $('input[name=trip_point_from_longitude]').val(data.fromLongitude).trigger('input');
        
        $('input[name=trip_point_to_latitude]').val(data.toLatitude).trigger('input');
        $('input[name=trip_point_to_longitude]').val(data.toLongitude).trigger('input');
        
        $('input[name=trip_point_price]').val(data.price);
        
        $('input[name=trip_point_waiting_time]').val(data.waitingTime);


        const tripAt = new Date(data.tripAt);
        const tripAtFormattedDate = tripAt.toISOString().split("T")[0];
        
        $('input[name=trip_point_trip_at]').val(tripAtFormattedDate);
        
        const leaveAt = new Date(data.leaveAt);
        const leaveAtFormattedDate = leaveAt.toISOString().split("T")[0];
        
        $('input[name=trip_point_leave_at]').val(leaveAtFormattedDate);
        
        $('input[name=trip_point_from_address]').val(data.fromAddress);
        $('input[name=trip_point_to_address]').val(data.toAddress);
    }

    function prepareTripPointForm(form) {
        changeKeyName('trip_point_id', 'id', form);
        
        changeKeyName('trip_point_from_latitude', 'fromLatitude', form);
        changeKeyName('trip_point_from_longitude', 'fromLongitude', form);
        
        changeKeyName('trip_point_to_latitude', 'toLatitude', form);
        changeKeyName('trip_point_to_longitude', 'toLongitude', form);
        
        changeKeyName('trip_point_price', 'price', form);
        changeKeyName('trip_point_trip_at', 'tripAt', form);
        changeKeyName('trip_point_leave_at', 'leaveAt', form);
        changeKeyName('trip_point_waiting_time', 'waitingTime', form);
        
        changeKeyName('trip_point_from_address', 'fromAddress', form);
        changeKeyName('trip_point_to_address', 'toAddress', form);

        return form;
    }

    function changeKeyName(oldKey, newKey, form) {
        // Get the old value associated with the old key
        let originalValue = form.get(oldKey);

        // Set the new key-value pair
        form.append(newKey, originalValue);

        // Delete the original key-value pair
        form.delete(oldKey);

        return form;
    }
});


/// from map

// Initialize the map
let from_map = new google.maps.Map(document.getElementById('from_map'), {
    center: { lat: 31.189944140292372, lng: 31.189944140292372 }, // Set the initial center of the map
    zoom: 12 // Set the initial zoom level
});

// Add a marker to the map
let from_marker = new google.maps.Marker({
    map: from_map,
    position: { lat: 31.189944140292372, lng: 31.189944140292372 }, // Set the initial position of the marker
    draggable: true // Allow the marker to be dragged
});

// Update the latitude and longitude inputs when the marker is dragged
google.maps.event.addListener(from_marker, 'dragend', function (event) {
    let position = from_marker.getPosition();
    $('input[name=trip_point_from_latitude]').val(position.lat());
    $('input[name=trip_point_from_longitude]').val(position.lng());

    changeAddress($('input[name=trip_point_from_address]'), position.lat(), position.lng());
});

// Update the marker position when the latitude or longitude inputs change
$('input[name=trip_point_from_latitude], input[name=trip_point_from_longitude]').on('input change', function () {
    let lat = parseFloat($('input[name=trip_point_from_latitude]').val()) || 0;
    let lng = parseFloat($('input[name=trip_point_from_longitude]').val()) || 0;
    let newPosition = new google.maps.LatLng(lat, lng);

    from_marker.setPosition(newPosition);
    from_map.panTo(newPosition);

    changeAddress($('input[name=trip_point_from_address]'), lat, lng);
});

/// to map

// Initialize the map
let to_map = new google.maps.Map(document.getElementById('to_map'), {
    center: { lat: 31.189944140292372, lng: 31.189944140292372 }, // Set the initial center of the map
    zoom: 12 // Set the initial zoom level
});

// Add a marker to the map
let to_marker = new google.maps.Marker({
    map: to_map,
    position: { lat: 31.189944140292372, lng: 31.189944140292372 }, // Set the initial position of the marker
    draggable: true // Allow the marker to be dragged
});

// Update the latitude and longitude inputs when the marker is dragged
google.maps.event.addListener(to_marker, 'dragend', function (event) {
    let position = to_marker.getPosition();
    $('input[name=trip_point_to_latitude]').val(position.lat());
    $('input[name=trip_point_to_longitude]').val(position.lng());

    changeAddress($('input[name=trip_point_from_address]'), position.lat(), position.lng());
});

// Update the marker position when the latitude or longitude inputs change
$('input[name=trip_point_to_latitude], input[name=trip_point_to_longitude]').on('input change', function () {
    let lat = parseFloat($('input[name=trip_point_to_latitude]').val()) || 0;
    let lng = parseFloat($('input[name=trip_point_to_longitude]').val()) || 0;
    let newPosition = new google.maps.LatLng(lat, lng);

    to_marker.setPosition(newPosition);
    to_map.panTo(newPosition);

    changeAddress($('input[name=trip_point_to_address]'), lat, lng);
});

function changeAddress(element, lat, lng) {
    // Get location string (address) using Geocoding
    const geocoder = new google.maps.Geocoder();
    const latLng = new google.maps.LatLng(lat, lng);
    
    geocoder.geocode({ location: latLng }, (results, status) => {
        if (status === "OK" && results[0]) {
            let locationString = results[0].formatted_address;

            if (locationString) {
                element.val(locationString);
            }
        } else {
            console.log("Geocoder failed due to: " + status);
        }
    });
}