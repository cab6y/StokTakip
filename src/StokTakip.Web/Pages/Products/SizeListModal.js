$(function () {
    var l = abp.localization.getResource('StokTakip');
    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditModal');
    var sizeModal = new abp.ModalManager(abp.appPath + 'Products/SizeListModal');
    var dataTable = $('#sizeTable').DataTable(

        abp.libs.datatables.normalizeConfiguration({
            autoWidth: true,
            processing: true,
            responsive: true,
            colReorder: true,
            serverSide: true,
            retrieve: true,
            destroy: true,
            paging: true,
            info: true,
            bInfo: false,
            bFilter: false,
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(stokTakip.productSizes.productSize.getAll),

            columnDefs: [
                

                {
                    title: "Urun Adi",
                    data: "size"
                },
                {
                    title: "aciklama",
                    data: "description"
                },
               
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('OpenSize'),
                                    action: function (data) {
                                        sizeModal.open({ id: data.record.id });
                                    }
                                },

                                {
                                    text: l('Delete'),
                                    action: function (data) {
                                        stokTakip.products.product.
                                            delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                },

                            ]
                    }
                },
            ]

        })

    );
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#newProduct').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
})