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
            searching: true,
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

    $(function () {
        // Arama Yap -------Begin --------------
        function applySearch(searchQuery) {
            dataTable.search(searchQuery).draw();
            //dataTable.columns.adjust().draw(); //columlarý yeniden hesaplar
        }


        const FilterOperators = {
            Contains: "Contains", //Contains
            EQ: "EQ",//equals
            GE: "GE", //greater or equals
            GT: "GT", //greater than
            LE: "LE", // less or equals
            LT: "LT", //less than
            NE: "NE", //not equals
            BT: "BT",//between
        };
        function appentQuery(query, filterOperators) {
            let q;
            if (query.length > 0) {
                q = `AND ${query}`
            }

        }
        function Filter(path, operator, value) {
            let filterConstructor = {
                Value: "",
                Condition: "",
                Path: "",
            };
            filterConstructor.Value = value;
            filterConstructor.Condition = operator;
            filterConstructor.Path = path;
            return filterConstructor;
        }

        $("#SearchApply").click(function () {
            let searchQuery = new Promise(function (myResolve, myReject) {
                let Name = $('#Name').val();
                let gender = $('#gender').find(":selected").val();
                var aFilter = [];
                if (Name != "") {
                    aFilter.push(Filter("Name", FilterOperators.Contains, Name));
                }
                if (gender != "") {
                    aFilter.push(Filter("Gender", FilterOperators.Contains, gender));
                }
                let filterQuery = JSON.stringify(aFilter);
                console.log(filterQuery);
                myResolve(filterQuery);
            });
            searchQuery.then(
                function (value) { applySearch(value); }
            );
        });

        // Arama Yap -------End --------------
    });
    $(".dataTable_filters").hide();
})