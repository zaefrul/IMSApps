function GetSelect2Configuration(URL)
{
    var conf = {
        ajax: {
            url: URL,
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    search: params.term
                };
            },
            processResults: function (data, params) {
                // parse the results into the format expected by Select2
                // since we are using custom formatting functions we do not need to
                // alter the remote JSON data, except to indicate that infinite
                // scrolling can be used
                params.page = params.page || 1;

                return {
                    results: data.results,
                    pagination: {
                        more: (params.page * 30) < data.total_count
                    }
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
        minimumInputLength: 1
    };
    return conf;
}
console.log(GetSelect2Configuration("../api/aVarieties"));
var invitemsel = GetSelect2Configuration("../api/aVarieties");
var suppliersel = GetSelect2Configuration("../api/aSuppliers");
var vendorsel = GetSelect2Configuration("../api/aVendors");
$(document).ready(function () {
    $('#datetimepicker4').datetimepicker();
    $(".varieties").select2(invitemsel);
    $("#suppliersel").select2(suppliersel);
    $("#vendorsel").select2(vendorsel);
    $(document).on("click", "#addvar", function (evnt) {
        $("select.varieties").select2("destroy");
        $("#sourcedata").clone().removeAttr("id").appendTo($("#itemsform"));
        $("select.varieties").select2(invitemsel);
    });
    $(document).on("click", "#removeitm", function () {
        $(this).parent().parent().remove();
        calculatetotal();
    });
    $(document).on("change", "#variety", function () {
        var slctbtn = $(this);
        $.get(
            "../api/aVarieties",
            {
                id: $(this).val()
            },
            function (data) {
                slctbtn.parent().parent().find("#cost").val(data.Cost);
                slctbtn.parent().parent().find("#qtys").val(1);
                calculatetotal();
            }
        ).fail(function(){
            alert("Failed to retrieve cost data");
        });
    });

    var calculatetotal = function () {
        var qtys = $("input[name='qtys[]']").map(function () { return $(this).val() }).get();
        var cost = $("input[name='cost[]']").map(function () { return $(this).val() }).get();
        var grandtotal = 0;
        $("input[name^=total").each(function (index) {
            var total = qtys[index] * cost[index];
            $(this).val(total);
            grandtotal += total;
        });
        $("input[name=grandtotal]").val(grandtotal);
    }
    $(document).on("change", "input", calculatetotal);
});