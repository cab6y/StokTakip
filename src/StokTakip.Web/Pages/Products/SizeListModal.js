$(function () {
    var l = abp.localization.getResource('StokTakip');
    var createModal = new abp.ModalManager(abp.appPath + 'Products/SizeCreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/SizeEditModal');
    var dataTable = $('#sizeTable').DataTable(

        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            ajax: abp.libs.datatables.createAjax(stokTakip.productSizes.productSize.getAll),

            columnDefs: [
                

                {
                    title: "Beden",
                    data: "size"
                },
                {
                    title: "aciklama",
                    data: "description"
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
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                               

                                {
                                    text: l('Delete'),
                                    action: function (data) {
                                        stokTakip.productSizes.productSize.
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
    $(".dataTable_filters").hide();
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#newProductSize').click(function (e) {
        e.preventDefault();
        createModal.open({ id: $('#sizes_ProductId').val() });
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

        $("#sizes_ProductId").ready(function () {
            let searchQuery = new Promise(function (myResolve, myReject) {

                let size = $('#sizes_ProductId').val();
               
                var aFilter = [];
                if (size != "") {
                    aFilter.push(Filter("Size", FilterOperators.Contains, size));
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
})