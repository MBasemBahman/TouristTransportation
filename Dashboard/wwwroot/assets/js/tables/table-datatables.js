'use strict';
$(function () {

    
    var isRtl = $('html').attr('data-textdirection') === 'rtl';
    
    var dt_ajax_table = $('.datatables')   

    if (dt_ajax_table.length) {

        $.extend(true, $.fn.dataTable.defaults, {
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

                        if ($('#profile').attr('href') != undefined) {
                            actions += '<a href="' + $('#profile').attr('href') + "/" + full.id + '" class="dropdown-item">' +
                                feather.icons['file-text'].toSvg({ class: 'font-small-4 me-50' }) +
                                '' + $("#ProfileLbl").val() + '</a>';
                        }
                        if ($('#details').attr('href') != undefined) {
                            actions += '<a href="' + $('#details').attr('href') + "/" + full.id + '" class="dropdown-item modalbtn">' +
                                feather.icons['file-text'].toSvg({ class: 'font-small-4 me-50' }) +
                                '' + $("#DetailsLbl").val() + '</a>';
                        }

                        if ($('#attachment').attr('href') != undefined) {
                            var routeAttachmentData = '';
                            if ($("#routeAttachmentData").length > 0) {
                                routeAttachmentData = $("#routeAttachmentData").val();
                            }

                            actions += '<a href="' + $('#attachment').attr('href') + "/" + full.id + '' + routeAttachmentData + '" class="dropdown-item">' +
                                feather.icons['file-text'].toSvg({ class: 'font-small-4 me-50' }) +
                                '' + $("#AttachmentsLbl").val() + '</a>';
                        }
                        
                        if ($('#customDetails').attr('href') != undefined) {
                            var modalType = 'modalbtn';
                            if ($("#ModalType").length > 0) {
                                modalType = $("#ModalType").val();
                            }
                            actions += '<a href="' + $('#customDetails').attr('href') + "/" + full.id + '" class="dropdown-item  ' + modalType + '">' +
                                feather.icons['file-text'].toSvg({ class: 'font-small-4 me-50' }) +
                                '' + $("#customDetailsLabel").val() + '</a>';
                        }

                        if ($('#partialViewURL').attr('href') != undefined) {

                            actions += '<a href="' + $('#partialViewURL').attr('href') + "/" + full.id + '" class="dropdown-item  partialViewURL">' +
                                feather.icons[$("#partialViewIcon").val()].toSvg({ class: 'font-small-4 me-50' }) +
                                '' + $("#partialViewLabel").val() + '</a>';

                        }
                        if ($('#delete').attr('href') != undefined) {
                            actions += '<a href="' + $('#delete').attr('href') + "/" + full.id + '" class="dropdown-item modalbtn">' +
                                feather.icons['trash-2'].toSvg({ class: 'font-small-4 me-50' }) +
                                '' + $("#RemoveLbl").val() + '</a>';
                        }
                        if ($('#deleteCustom').attr('href') != undefined) {
                            actions += '<a href="' + $('#deleteCustom').attr('href') + "/" + full.id + '?returnToIndex=true" class="dropdown-item modalbtn">' +
                                feather.icons['trash-2'].toSvg({ class: 'font-small-4 me-50' }) +
                                '' + $("#RemoveLbl").val() + '</a>';
                        }

                        actions += '</div>' +
                            '</div>';

                        if ($('#edit').attr('href') != undefined) {
                            var routeData = '';
                            if ($("#routeData").length > 0) {
                                routeData = $("#routeData").val();
                            }
                            actions += '<a href="' + $('#edit').attr('href') + "/" + full.id + '' + routeData + '" class="item-edit">' +
                                feather.icons['edit'].toSvg({ class: 'font-small-4' }) +
                                '</a>';
                        }

                        if ($('#editCustom').attr('href') != undefined) {
                            actions += '<a href="' + $('#editCustom').attr('href') + "/" + full.id + '?returnToIndex=true"  class="item-edit">' +
                                feather.icons['edit'].toSvg({ class: 'font-small-4' }) +
                                '</a>';
                        }

                        if ($('#editModal').attr('href') != undefined) {
                            var routeData = '';
                            if ($("#routeData").length > 0) {
                                routeData = $("#routeData").val();
                            }
                            actions += '<a href="' + $("#editModal").attr('href') + "/" + full.id + '' + routeData +'"  class="item-edit modalbtn">' +
                                feather.icons['edit'].toSvg({ class: 'font-small-4' }) +
                                '</a>';
                        }
                        if ($('#editProfile').attr('href') != undefined) {
                            actions += '<a href="' + $('#edit').attr('href') + "/" + full.id + '?IsProfile=true" class="item-edit">' +
                                feather.icons['edit'].toSvg({ class: 'font-small-4' }) +
                                '</a>';
                        }
                        return (actions);
                    }
                }
            ],
            dom: '<"p-1"<"head-label"><"dt-action-buttons text-end"B>><"d-flex flex-wrap justify-content-between align-items-center mx-0 row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>t<"d-flex justify-content-between mx-0 row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',
            displayLength: 7,
            lengthMenu: [7, 10, 25, 50, 75, 100, 1000],
            buttons: [
                {
                    text: feather.icons['plus'].toSvg({ class: 'me-50 font-small-4' }) + $("#AddNewLbl").val(),
                    className: 'create-new btn btn-primary me-2',
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
                    className: 'create-new btn btn-primary me-2',
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
                },
                {
                    text: feather.icons['edit'].toSvg({ class: 'me-50 font-small-4' }) + $('#editSpecific').attr('data-label'),
                    className: `${$('#editSpecific').attr('data-spec-class') != undefined ? 
                        $('#editSpecific').attr('data-spec-class') : ""} btn btn-primary me-2`,
                    init: function (api, node, config) {
                        if ($('#editSpecific').attr('href') == undefined) {
                            $(node).hide();
                        } else {
                            $(node).removeClass('btn-secondary');
                        }
                    },
                    action: function (e, dt, button, config) {

                    }
                },
                {
                    text: feather.icons['edit'].toSvg({ class: 'me-50 font-small-4' }) + $('#anotherEditSpecific').attr('data-label'),
                    className: `${$('#anotherEditSpecific').attr('data-spec-class') != undefined ?
                        $('#anotherEditSpecific').attr('data-spec-class') : ""} btn btn-success me-2`,
                    init: function (api, node, config) {
                        if ($('#anotherEditSpecific').attr('href') == undefined) {
                            $(node).hide();
                        } else {
                            $(node).removeClass('btn-secondary');
                        }
                    },
                    action: function (e, dt, button, config) {
                        window.location = $('#anotherEditSpecific').attr('href');
                    }
                },
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

                        if ($('#export').attr('href') != undefined) {
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
                            $(node).closest('.dt-buttons').removeClass('btn-group').addClass('d-inline-flex flex-wrap justify-content-start');
                        }, 50);
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
            }

        });

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

    }

    function strtrunc(str, num) {
        if (str.length > num) {
            return str.slice(0, num) + "...";
        }
        else {
            return str;
        }
    }

    // Filter form control to default size for all tables
    $('.dataTables_filter .form-control').removeClass('form-control-sm');
    $('.dataTables_length .form-select').removeClass('form-select-sm').removeClass('form-control-sm');
});

