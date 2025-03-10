$(document).on('click', '[data-dismiss="modal"]', function () {
    $('#form-modal').modal('hide');
    $('.modal-backdrop').remove();
    $('body').removeClass('modal-open');
});
