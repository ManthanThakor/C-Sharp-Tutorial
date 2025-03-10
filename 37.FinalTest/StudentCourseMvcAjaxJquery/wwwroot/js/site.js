
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

jQueryAjaxPost = (form, refreshFunction) => {
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
                    $('.modal-backdrop').remove();
                    $('body').removeClass('modal-open');

                    if (typeof window[refreshFunction] === "function") {
                        window[refreshFunction]();
                    } else {
                        console.error(`${refreshFunction} is not defined!`);
                    }
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

function jQueryAjaxDelete(form, refreshFunction) {
    if (confirm('Are you sure you want to delete this record?')) {
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
                        $('.modal-backdrop').remove();
                        $('body').removeClass('modal-open');

                        if (typeof window[refreshFunction] === "function") {
                            window[refreshFunction]();
                        } else {
                            console.error(`${refreshFunction} is not defined!`);
                        }
                    } else {
                        alert("Error deleting record!");
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
}
