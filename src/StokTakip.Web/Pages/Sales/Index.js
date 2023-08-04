$(function () {
    var l = abp.localization.getResource('StokTakip');
    var dataTable = $('#salesTable').DataTable(

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
            ajax: abp.libs.datatables.createAjax(stokTakip.sales.sale.getList),

            columnDefs: [
               

                {
                    title: "Adi",
                    data: "customerName"
                },
                {
                    title: "Soyadi",
                    data: "customerSurName"
                },
                {
                    title: "Email",
                    data: "customerEmail"
                },
                {
                    title: "Telefon",
                    data: "customerTelefon"
                },
                {
                    title: "Urun Ad",
                    data: "productName"
                },
                {
                    title: "Beden",
                    data: "size"
                },
                {
                    title: "Adet",
                    data: "quantity"
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Iade'),
                                    action: function (data) {
                                        stokTakip.sales.sale.
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
   
})