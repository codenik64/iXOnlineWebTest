
function InitializeDataTable(TableName) {
    $(document).ready(function () {
        $(TableName).DataTable();
    });

}
function InitializeDataTablesFun() {

    $(document).ready(function () {
        $('#myData').DataTable();
    });

}
function CloseModal(ModalId) {
    $(ModalId).modal('hide');
}

