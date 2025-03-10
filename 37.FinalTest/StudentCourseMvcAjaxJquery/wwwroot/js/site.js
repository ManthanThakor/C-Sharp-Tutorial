$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    });
};

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.success) {
                    $('#form-modal').modal('hide');
                    refreshCourseTable(); // Reload the table data
                } else {
                    $('#form-modal .modal-body').html(res);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
        return false;
    } catch (ex) {
        console.log(ex);
    }
};

jQueryAjaxDelete = form => {
    if (confirm('Are you sure you want to delete this course?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.success) {
                        alert(res.message);
                        refreshCourseTable(); // Reload the table data
                    } else {
                        alert(res.message);
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        } catch (ex) {
            console.log(ex);
        }
    }
    return false;
};
