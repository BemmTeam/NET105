
$(document).ready(function () {
    LoadList();
    Event();
})



function LoadList() {

    $.ajax({

        url: "/Cart/Carts",
        type: "get",
        success: function (response) {
            InsertList(response.data);
        }
    })
}

function InsertList(data) {
    console.log(data);

    $("#tblCart").empty();
    if (data.length <= 0 || data == null) {
        tr = "<lable> Không có sản phẩm nào !</lable>";
    }
    var count = 0;
    $.each(data, function (k, v) {

        var html = ` <li  class="header_cart-item">
        <img src="/images/products/` + v.product.imageUrl +`" alt="" class="header_cart-img" />
        <div class="header_cart-item-info">
            <div class="header_cart-item-head">
                <h4 class="header_cart-item-name">
               ` + v.product.name + `
                </h4>
                <div class="header_cart-item-price-wrap">
                    <label class="header_cart-item-price">` + v.product.price + ` VNĐ</label>
                    <label class="header_cart-item-multiply">X</label>
                    <label class="header_cart-item-qnt">` + v.quantity +`</label>
                </div>
                <label data-id= " ` + v.cartDetailId + `" class="header_cart-item-remove btnRemoveCart"><i style="font-size: 20px;" class="fa fa-times-circle ml-2"></i></label>
            </div>
          
        </div>
    </li>`
        
    count += parseInt(v.quantity);

    $("#tblCart").append(html);

    })
    $("#cartCount").text(count);
}


function Event() {

    // btn add cart 
    $(document).on("click", ".btnAddCart", function () {
        var _id = $(this).data("id");
        var _Quantity = $("#sst").val();
        var qnt = $("#qnt-" + _id).text();
        // if(qnt <= 0)
        // {
        //     ShowAlert("Món đã hết hàng vui lòng chọn món khác", false);
        //     return;
        // }
        if(_Quantity == null) _Quantity = 1;

        $.ajax({

            url: "/Cart/Add",
            type: "post",
            data: {
                id: _id,
                quantity: _Quantity 
            },
            success: function (response) {
                if(response.isSuccess)
                {
                    $("#qnt-" + _id).text(qnt - _Quantity); 
                    LoadList();
                }
                ShowAlert(response.message, response.isSuccess);
            }
        })
    })

      // btn remove cart 
    $(document).on("click", ".btnRemoveCart", function () {
        var _id = $(this).data("id");
        $.ajax({

            url: "/Cart/Remove",
            type: "delete",
            data: {
                id: _id,
            },
            success: function (response) {
                if(response.isSuccess)
                {
                    LoadList();
                }
                ShowAlert(response.message, response.isSuccess);
            }
        })
    })
}