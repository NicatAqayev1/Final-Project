$(document).ready(function () {
    $(document).on("click", ".addtocart", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");

        fetch(url).then(res => {
            return res.text()
        }).then(data => {
            $(".minicart-inner").html(data);

            fetch("../../home/count/").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)
            })

        })
        $(".ActionMessage").html("Added to your packed");
        $(".ActionMessage").css({
            "opacity": "1",
            "visibility": "visible",
            "right": "30px",
            "background-color" : "green"
        })
       
        setTimeout(MessageAction, 3000);
    })
    $(document).on("click", ".outofstock", function (e) {
        e.preventDefault();
        $(".ActionMessage").html("There is no such product in stock. Please choose another one")
        $(".ActionMessage").css({
            "opacity": "1",
            "visibility": "visible",
            "right": "30px",
            "background-color" : "#c1001c"
        })
        setTimeout(MessageAction, 3000);
    })
    $(document).on("click", "#addbasketbtn", function (e) {
        e.preventDefault()

        let url = $("#basketform").attr("action")
        let count = $("#productcount").val();

        var e = document.getElementById("colorids");
        var colorID = e.options[e.selectedIndex].value;

        var e = document.getElementById("sizeids");
        var sizeID = e.options[e.selectedIndex].value;

        console.log(colorID)
        console.log(sizeID)

        url = url + "?count=" + count + "&colorid=" + colorID + "&sizeid=" + sizeID;
        fetch(url).then(response => {
            return response.text();
        }).then(data => {
            $(".minicart-inner").html(data)
            fetch("../../home/count/").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)
            })
        })
    })
    $(document).on("click", ".deletecard", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => {
            fetch("../../Basket/GetBasket").then(response => response.text()).then(data => $(".minicart-inner").html(data))


            fetch("../../home/count").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)
            })
            return response.text()
        })
            .then(data => {
            $(".basketContainer").html(data);
        })


    })
    $(document).on("click", ".deletebasket", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => {
            fetch("../../Basket/GetCard").then(response => response.text()).then(data => $(".basketContainer").html(data))

            fetch("../../home/count").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)
            })
            return response.text()
        }).then(data => $(".minicart-inner").html(data))
    })
    $(document).on("click",".dec", function (e) {

        e.preventDefault();

        var id = $(this).next().attr("data-id");
        var color = parseInt($(this).next().attr("data-color"));
        var size = parseInt($(this).next().attr("data-size"));

        var productCount = parseInt($(this).next().attr("data-productCount"));

        let prodCount = parseInt($(this).next(".prod-count").val());

        if (prodCount <= 1) {
            prodCount = 1
        }
        else if (prodCount <= productCount) {
            prodCount--;
        }
        else {
            prodCount = productCount;
        }

        var count = prodCount;

        fetch("../../Basket/Update" + "?id=" + id + "&count=" + count + "&color=" + color + "&size=" + size).then(response => {

            fetch("../../Basket/GetBasket").then(response => response.text())
                .then(data => $(".minicart-inner").html(data))
            return response.text()

        }).then(data => $(".basketContainer").html(data))



        $(this).next(".prod-count").val(prodCount);
    })
    $(document).on("click", ".inc", function (e) {

        e.preventDefault();

        var id = $(this).prev().attr("data-id");
        var color = parseInt($(this).prev().attr("data-color"));
        var size = parseInt($(this).prev().attr("data-size"));

        var productCount = parseInt($(this).prev().attr("data-productCount"));


        let prodCount = parseInt($(this).prev(".prod-count").val());
        if (prodCount < productCount) {
            prodCount++;
        } else {
            prodCount = productCount;
        }
        var count = prodCount;
        fetch("../../Basket/Update" + "?id=" + id + "&count=" + count + "&color=" + color + "&size=" + size).then(response => {

            fetch("../../Basket/GetBasket").then(response => response.text())
                .then(data => $(".minicart-inner").html(data))
            return response.text()

        }).then(data => $(".basketContainer").html(data))

        $(this).prev(".prod-count").val(prodCount);
    })
    $(document).on("keyup", ".prod-count", function () {
        var productCount = parseInt($(this).attr("data-productCount"));
        var count;

        if (parseInt($(this).val()) <= parseInt(productCount) && parseInt($(this).val()) > 0) {
            count = parseInt($(this).val());
        }
        else if (parseInt($(this).val()) > parseInt(productCount)) {
            count = parseInt(productCount);
        } else {
            count = 1;
        }



        if ($(this).hasClass("forHeaderBasket")) {

            var id = $(this).attr("data-id");
            var color = parseInt($(this).attr("data-color"));
            var size = parseInt($(this).attr("data-size"));
            fetch("../../Basket/Update" + "?id=" + id + "&count=" + count + "&color=" + color + "&size=" + size).then(response => {

                fetch("../../Basket/GetBasket").then(response => response.text())
                    .then(data => $(".minicart-inner").html(data))
                return response.text()

            }).then(data => $(".basketContainer").html(data))

        }

        $(this).val(count);;

    })
    //login sql or basket
    $(document).on("click", ".loginSubmit", function (e) {
        e.preventDefault();
        $(".login-basket").css({
            "opacity": "1",
            "visibility" : "visible"
        })
        $(".overlay-cart").css({
            "opacity": "1",
            "visibility": "visible"
        })
        fetch("../Account/LoginBasket").then(res => {
            return res.text()
        }).then(data => {
            $(".login-basket").html(data);
        })
    })
    $(document).on("click", ".default-link", function (e) {
        e.preventDefault();
    })

    $(document).on("keyup", "#searchBtn", function (e) {
        e.preventDefault()
        console.log($(this).val())
        let url = $("#searchForm").attr("action");
       
        fetch(url + "?key=" + $(this).val()).then(res => {
            return res.text()
        }).then(data => {
            $("#productList").html(data)
        })
    })
    //Product-detail-partial
    $(document).on("click", ".sizes a", function (e) {
        e.preventDefault()
        $(this).addClass("active-det");
        $(this).siblings().removeClass("active-det")

        var id = $(this).attr("data-id");
        var size = $(".size.active-det").attr("data-size");
        var color = $(".color.active-det").attr("data-color");
        fetch("../DetailSizeColor" + "?id=" + id + "&colorid=" + color + "&sizeid=" + size).then(res => {
            return res.text()
        }).then(data => {
            $(".rightPartial").html(data);
        })
    })
    $(document).on("click", ".colors a", function (e) {
        e.preventDefault()
        $(this).addClass("active-det");
        $(this).siblings().removeClass("active-det")
        var id = $(this).attr("data-id");
        var color = $(".color.active-det").attr("data-color");
        var size = $(".size.active-det").attr("data-size");

        fetch("../DetailSizeColor" + "?id=" + id + "&colorid=" + color + "&sizeid=" + size).then(res => {
            return res.text()
        }).then(data => {
            $(".rightPartial").html(data);
        })
    })
    //Modal-detail-partial
    $(document).on("click", ".sizesm a", function (e) {
        e.preventDefault()
        $(this).addClass("active-det");
        $(this).siblings().removeClass("active-det")
        var id = $(this).attr("data-id");
        var size = $(".sizem.active-det").attr("data-size");
        var color = $(".colorm.active-det").attr("data-color");
        fetch("../home/DetailSizeColor" + "?id=" + id + "&colorid=" + color + "&sizeid=" + size).then(res => {
            return res.text()
        }).then(data => {
            $(".right-modal").html(data);
        })
    })
    $(document).on("click", ".colorsm a", function (e) {
        e.preventDefault()
        $(this).addClass("active-det");
        $(this).siblings().removeClass("active-det")
        var id = $(this).attr("data-id");
        var color = $(".colorm.active-det").attr("data-color");
        var size = $(".sizem.active-det").attr("data-size");

        fetch("../home/DetailSizeColor" + "?id=" + id + "&colorid=" + color + "&sizeid=" + size).then(res => {
            return res.text()
        }).then(data => {
            $(".right-modal").html(data);
        })
    })
    //Review-blog
    $(document).on("click", ".addReview", function (e) {

        e.preventDefault()
        var id = $(this).attr("data-bid");
        var Message = $("#MessageMain").val().trim()
            fetch("AddReview" + "?Message=" + Message + "&bid=" + id).then(res => {
                return res.text();
            }).then(data => {
                $(".comments").html(data);
                $("#MessageMain").val("");

                fetch("CommentCount" + "?id=" + id).then(response => {
                    return response.text()
                }).then(data => {
                    $(".CommentCount").html(data);
                })
            })
    })
    //Review-product
    $(document).on("click", ".writeReview", function (e) {
        e.preventDefault();
        $(".prod-review-form").slideToggle();
    })
    $(document).on("click", ".star", function () {
        window.scrollTo();
        console.log($(this).val())
        var star = $(this).val();
        $("#ProductReviewSubmit").attr("data-star", star);
    })
    $(document).on("click", "#ProductReviewSubmit", function (e) {
        e.preventDefault();

        var Message = $(".prod-review-form #Message").val();
        var id = $(this).attr("data-id");
        var star = $(this).attr("data-star");
        fetch("../AddProdReview" + "?Message=" + Message + "&star=" + star + "&id=" + id).then(res => {
            return res.text();
        }).then(data => {
            $(".prod-review-form #Message").val("")
            $(".prod-review-form #Name").val("")
            $(".prod-review-form #Email").val("")
            $(".prod-review-form .rate label").css({
                "color": "#ccc !important"
            });

            $(".Prodcomments").html(data);

            fetch("../ProdCommentCount" + "?id=" + id).then(response => {
                return response.text()
            }).then(data => {
                $(".prodCommentCount").html(data);
            })
            fetch("../GeneralStar" + "?id=" + id).then(res => {
                return res.text()
            }).then(data => {
                $(".reviewStar").html(data);
                $(".icons-product").html(data);
            })
        })
    })

    $(document).on("click", ".pdec", function (e) {

        e.preventDefault();
        let prodCount = parseInt($(this).next(".prod-count").val());

        if (prodCount != 1) {
            prodCount--;
        }

        $(this).next(".prod-count").val(prodCount);
    })
    $(document).on("click", ".pinc", function (e) {

        e.preventDefault();
        var productCount = parseInt($(this).prev().attr("data-productCount"));

        let prodCount = parseInt($(this).prev(".prod-count").val());

        if (prodCount != productCount) {
            prodCount++;
        }
        $(this).prev(".prod-count").val(prodCount);
    })
    $(document).on("click", ".addbasketfromPD", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        var prodCount = parseInt($(this).prev().find(".prodDetailCount").val());
        fetch(url + "&count=" + prodCount).then(res => {
            return res.text()
            console.log(url)
        }).then(data => {
            $(".minicart-inner").html(data);
            fetch("../../home/count/").then(res => {
                console.log("slam1")
                return res.text()
                console.log("salam2")
            }).then(data => {
                $(".notification").html(data)
            })
        })

        $(".ActionMessage").html("Added to your packed");
        $(".ActionMessage").css({
            "opacity": "1",
            "visibility": "visible",
            "right": "30px",
            "background-color": "green"
        })
        setTimeout(MessageAction, 3000);
    })
    //wishlist
    $(document).on("click", ".addtowishlist", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(res => {
            return res.text()
        }).then(data => {
            $(".wishCount").html(data);
        })
    })
    var MessageAction = function () {
        $(".ActionMessage").css({
            "opacity": "0",
            "visibility": "hidden",
            "right": "0px"
        })
    }
    $(document).on("click", ".removeWishlist", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url)
            .then(res => {
            return res.text()
        }).then(data => {
            $(".wishlist-container").html(data);
        })
    })
    $(document).on("click", ".sendemail", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        let mail = $(".forSendEmail").val();
        fetch(url + "?mailTo=" + mail).then(res => {
            return res.text();
        }).then(data => {
            $(".EmailVerify").html(data);
        })
    })
    //Blog tag filter
    $(document).on("click", ".blogtagFilter", function (e) {
        e.preventDefault();
        if ($(this).hasClass("active-filterTag")) {
            $(this).removeClass("active-filterTag");
        } else {
            //$(".blogtagFilter").removeClass("active-filterTag");
            $(this).addClass("active-filterTag");
        }
        let url = $(this).attr("href");
        var tagIds = document.querySelectorAll(".active-filterTag");
        tagId = "";

        for (var i = 0; i < tagIds.length; i++) {
            tagId += tagIds[i].getAttribute("data-tag");
        }
        fetch(url + "?tag=" + tagId.split("").toString() + "&page=" + $(".page-link-blog").attr("data-page")).then(res => {
            return res.text();
        }).then(data => {
            $(".blog-right").html(data);
        })
    })
    $(document).on("click", ".page-link-blog", function (e) {
        e.preventDefault()
        var tagIds = document.querySelectorAll(".active-filterTag");
        tagId = "";

        for (var i = 0; i < tagIds.length; i++) {
            tagId += tagIds[i].getAttribute("data-tag");
        }
        fetch("../blog/toTag" + "?tag=" + tagId.split("").toString() + "&page=" + $(this).attr("data-page")).then(res => {
            return res.text();
        }).then(data => {
            $(".blog-right").html(data);
        })
    })
    // Product review
    $(document).on("click", ".deleteCommentp", function (e) {
        e.preventDefault();
        var id = $(this).attr("data-id");
        var bid = $(this).attr("data-bid");
        fetch("../DeleteReview" + "?id=" + id).then(res => {
            return res.text();
        }).then(data => {
            $(".review .Prodcomments").html(data);

            fetch("../ProdCommentCount" + "?id=" + bid).then(response => {
                return response.text()
            }).then(data => {
                $(".prodCommentCount").html(data);
            })
            fetch("../GeneralStar" + "?id=" + bid).then(res => {
                return res.text()
            }).then(data => {
                $(".reviewStar").html(data);
                $(".icons-product").html(data);
            })
        })
    })
    $(document).on("click", ".changeCommentp", function (e) {
        e.preventDefault();
        $(this).parent().parent().parent().next("#editForma").slideToggle()
    })
    $(document).on("click", ".editCommentp", function (e) {
        e.preventDefault();

        var Message = $("#MessageEditp").val()
        fetch("../Edit" + "?Message=" + Message + "&id=" + $(this).attr("data-rid")).then(res => {
            return res.text();
        }).then(data => {
            $(".Prodcomments").html(data);
            $("#MessageEditp").val("")
        })
    })
    //Shop filter
    $(document).on("click", ".shopFilter", function (e) {
        e.preventDefault();
        if ($(this).hasClass("size")) {
            $(this).toggleClass("active-size");
        }
        if ($(this).hasClass("color")) {
            $(this).toggleClass("active-color");
        }
        if ($(this).hasClass("speciality")) {
            if ($(this).hasClass("active-speciality")) {
                $(this).removeClass("active-speciality");
            } else {
                $(".speciality").removeClass("active-speciality");
                $(this).addClass("active-speciality");
            }
        }
        if ($(this).hasClass("category")) {
            if ($(this).hasClass("active-category")) {
                $(this).removeClass("active-category");
            } else {
                $(".category").removeClass("active-category");
                $(this).addClass("active-category");
            }
        }
        if ($(this).hasClass("vendor")) {
            if ($(this).hasClass("active-vendor")) {
                $(this).removeClass("active-vendor");
            } else {
                $(".vendor").removeClass("active-vendor");
                $(this).addClass("active-vendor");
            }
        }
        ShopFetch();
    })
    $(document).on("change", ".selectfilter", function () {
        ShopFetch();
    })

    function ShopFetch() {
        let countby = $(".countby").find(":selected").val();
        let sortby = $(".sortby").find(":selected").val();
        var sizeIds = document.querySelectorAll(".active-size");
        var colorIds = document.querySelectorAll(".active-color");
        var Sids = "";
        var Cids = "";
        var SPids = "";
        var VNids = "";
        var cat = "";
        var minP = $("#input-left").val();
        var maxP = $("#input-right").val();
        if ($(".active-category").attr("data-id") != undefined) {
            cat = $(".active-category").attr("data-id");
        }
        if ($(".active-speciality").attr("data-id") != undefined) {
            SPids = $(".active-speciality").attr("data-id");
        }
        if ($(".active-vendor").attr("data-id") != undefined) {
            VNids = $(".active-vendor").attr("data-id");
        }
        for (var i = 0; i < sizeIds.length; i++) {
            Sids += sizeIds[i].getAttribute("data-id");
        }
        for (var i = 0; i < colorIds.length; i++) {
            Cids += colorIds[i].getAttribute("data-id");
        }

        fetch("../../shop/filter"
            + "?sizes=" + Sids.split("").toString()
            + "&colors=" + Cids.split("").toString()
            + "&specs=" + SPids
            + "&vendors=" + VNids
            + "&countby=" + parseInt(countby)
            + "&sortby=" + parseInt(sortby)
            + "&category=" + cat
            + "&minPrice=" + parseInt(minP)
            + "&maxPrice=" + parseInt(maxP)
        ).then(res => {
            return res.text();
        }).then(data => {
            $(".shop-products").html(data)
        })
    }

    var maxRVal = 5000;
    $(document).on("keyup", "#min-value-price", function () {
        if (parseInt($(this).val()) >= maxRVal) {
            $(this).val(maxRVal);
        } else if (parseInt($(this).val()) <= 0) {
            $(this).val(0);
        }

        $("#input-left").val($(this).val());
        setLeftValue();
    })
    $(document).on("keyup", "#max-value-price", function () {
        if (parseInt($(this).val()) >= maxRVal) {
            $(this).val(maxRVal);
        } else if (parseInt($(this).val()) <= 0) {
            $(this).val(0);
        }

        $("#input-right").val($(this).val());
        setLeftValue();
    })
    function setLeftValue() {
        $("#input-left").attr("max", maxRVal);
        const [min, max] = [parseInt($("#input-left").attr("min")), parseInt($("#input-left").attr("max"))];
        $("#input-left").val(Math.min(parseInt($("#input-left").val()), parseInt($("#input-right").val()) - 1));
        const percent = (($("#input-left").val() - min) / (max - min)) * 100;
        //thumbLeft.style.left = percent + "%";
        $(".slider > .thumb.left").css({
            "left": percent + "%"
        })
        //range.style.left = percent + "%";
        $(".slider > .range").css({
            "left": percent + "%"
        })
        $("#min-value-price").val($("#input-left").val());
        ShopFetch();
    };
    function setRightValue() {
        $("#input-right").attr("max",maxRVal);
        const [min, max] = [parseInt($("#input-right").attr("min")), parseInt($("#input-right").attr("max"))];
        $("#input-right").val(Math.max(parseInt($("#input-right").val()), parseInt($("#input-left").val()) + 1));
        const percent = (($("#input-right").val() - min) / (max - min)) * 100;
        //thumbRight.style.right = 100 - percent + "%";
        $(".slider > .thumb.right").css({
            "right": 100 - percent + "%"
        })
        //range.style.right = 100 - percent + "%";
        $(".slider > .range").css({
            "right": 100 - percent + "%"
        })
        $("#max-value-price").val($("#input-right").val());
        ShopFetch();
    };
    $(document).on("input", "#input-left", function () {
        setLeftValue();
    });
    $(document).on("input", "#input-right", function () {
        setRightValue();
    });
})