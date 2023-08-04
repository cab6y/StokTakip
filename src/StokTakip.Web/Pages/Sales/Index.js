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
            searching: true,
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
                let SurName = $('#SurName').val();
                let Telephone = $('#Telephone').val();
                var aFilter = [];
                if (Name != "") {
                    aFilter.push(Filter("Name", FilterOperators.Contains, Name));
                }
                if (SurName != "") {
                    aFilter.push(Filter("SurName", FilterOperators.Contains, SurName));
                } if (Telephone != "") {
                    aFilter.push(Filter("Telephone", FilterOperators.Contains, Telephone));
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