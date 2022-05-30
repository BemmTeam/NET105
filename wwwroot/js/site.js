// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



var myapp = angular.module("app" , []);

myapp.controller("mycontroller" , function($scope , $http){

    $scope.count = 0;
    $scope.quantity = 1;

    $scope.AddCart = function(id)
    {
        var quantity =   $scope.quantity ;
        $http.post(`https://localhost:5001/api/carts?id=${id}&quantity=${quantity}`).then(function(r)
        {

            var cart = r.data;
            console.log(r.data);
            var productId = cart.cartItem.product.productId; 
            var idcheck = document.getElementById(productId);

            if(idcheck)
            {
                var quantity = idcheck.querySelector(".header_cart-item-qnt");
                quantity.innerText = cart.cartItem.quantity;
                $scope.quantity = 1;

                return;
            }

             var box = angular.element(document.querySelector("#header_cart-list-item"))

             $scope.count++ ;
   
             var    html = ` <li id= "${productId}" class="header_cart-item">
                    <img src="/images/products/${cart.cartItem.product.imageUrl}" alt="" class="header_cart-img" />
                    <div class="header_cart-item-info">
                        <div class="header_cart-item-head">
                            <h4 class="header_cart-item-name">
                           ${cart.cartItem.product.name}
                            </h4>
                            <div class="header_cart-item-price-wrap">
                                <label class="header_cart-item-price">${cart.cartItem.product.price} VNĐ</label>
                                <label class="header_cart-item-multiply">X</label>
                                <label class="header_cart-item-qnt">${cart.cartItem.quantity}</label>
                            </div>
                            <label class="header_cart-item-remove"><i style="font-size: 20px;" class="fa fa-times-circle ml-2"></i></label>
                        </div>
                      
                    </div>
                </li>
             `
             box.append(html);
             $scope.quantity = 1;

        })
    }


   
    $http.get("https://localhost:5001/api/carts").then(function(response){
        
        $scope.testlist = response.data;
        console.log(response.data);
    })

})