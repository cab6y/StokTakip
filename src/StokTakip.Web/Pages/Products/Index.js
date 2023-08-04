$(function () {
    var l = abp.localization.getResource('StokTakip');
    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditModal');
    var sizeModal = new abp.ModalManager(abp.appPath + 'Products/SizeListModal');
    var saleModal = new abp.ModalManager(abp.appPath + 'Products/SaleModal');
    var dataTable = $('#productsTable').DataTable(

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
            ajax: abp.libs.datatables.createAjax(stokTakip.products.product.getAll),

            columnDefs: [
                {
                    orderable: false,
                    data: "image",
                    title: "resim",
                    className: 'text-center',
                    render: function (data, type, full, meta) {
                        return '<img src="' + data + '" style="max-width:150px;max-height:150px;"/>';
                    }
                },
               
                {
                    title: "Urun Adi",
                    data: "name"
                },
                {
                    title: "aciklama",
                    data: "description"
                },
                {
                    orderable: false,
                    data: "gender",
                    title:"cinsiyet",
                    className: 'text-center',
                    render: function (data, type, full, meta) {
                        if(data == 0)
                            return '<i class="fas fa-male"></i>';
                        if (data == 1)
                            return '<i class="fas fa-female"></i>';
                        if (data == 2)
                            return '<i class="fas fa-rainbow"></i>';
                    }
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
                                    text: l('Sale'),
                                    action: function (data) {
                                        saleModal.open({ productId: data.record.id });
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
    saleModal.onResult(function () {
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