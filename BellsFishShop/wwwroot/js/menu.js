//On load
getMenuData();
showFishAnimation();
showSustainabilityLink();

//Format numbers to currency
var currency = new Intl.NumberFormat('en-GB', {
    style: 'currency',
    currency: 'GBP'
});

function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
}

/*Fish animation on page*/
function showFishAnimation() {
    let maxHeight = $(window).height() - 100;
    $("svg#fish").css({ "top": getRandomInt(maxHeight) + "px" });
    $("svg#fish").removeClass("fish");
    $("svg#fish").addClass("fishAnimate");
    setTimeout(function () {
        $("svg#fish").addClass("fish");
        $("svg#fish").removeClass("fishAnimate");
        showFishAnimation();
    }, 16000);
}

function showSustainabilityLink() {
    let sustainabilityLink = $("#SustainabilityPolicyPopup");
    sustainabilityLink.addClass("show");
    setTimeout(function () {
        //sustainabilityLink.removeClass("show");
        sustainabilityLink.addClass("hide");
    }, 10000);
}

function textReplacements(txt) {
    txt = txt.replace('(V)', '<span class="veg-vegetarian"></span>');
    txt = txt.replace('(GF)', '<span class="glutenfree-gf1"></span><span class="glutenfree-gf2"></span>');
    return txt;
}

function getMenuData() {
    let menu = $("#MenuRef").val();

    let dataToLoad = `/MenuData/${menu}/?handler=Json`;

    $.get(dataToLoad, function (data) {
        
    })
        .then(data => {
            console.log(dataToLoad + " Loaded");
            try {
                //Save menu data to local storage
                localStorage.setItem("menuData", JSON.stringify(data));

                loadMenu(data);
            }
            catch (e) {
                let title = `Error Loading Menu Data`;
                let content = `Sorry an error occurred loading the menu data. Please check your internet connection and try again.`;

                doErrorModal(title, content);
            }
        })
        .fail(function () {
            let title = `Error Loading Menu Data`;
            let content = `Sorry an error occurred loading the menu data. Please check your internet connection and try again.`;

            doErrorModal(title, content);
        });
}

function loadMenu(data) {
    //First and only in array of menus - would allow drinks menu to be on same page
    var menuData = data.menuData[0];
    let isAdmin = $("#IsAdmin").val();
    let kioskScreen = $("#KioskScreen").val();

    try {
        let htmlData = "";
        for (let cat in menuData.menuCategory) {
            let category = menuData.menuCategory[cat];
            let showCategory = true;
            let numItems = category.menuItem.length;
            let numItemsPerColumn = Math.ceil(numItems / 3);
            let numItemInColumn = 0;

            if (kioskScreen > 0 && parseInt(kioskScreen) !== category.screenNumber) {
                showCategory = false;
            }

            if (showCategory === true) {
                let catTitleExtra = "";
                let catDescription = "";

                if (category.titleExtra !== null) {
                    catTitleExtra = ` <small class="text-muted">${category.titleExtra}</small>`;
                }

                if (category.description !== null) {
                    catDescription = `
                    <br />
                    <small class="text-muted">
                        ${category.description}
                    </small>`;
                }

                htmlData += `
                <div class="container MenuContent Spacer">
                    <div class="row">
                        <div class="col-md">
                            <div class="container alert alert-dark">
                                <div class="row">`;

                if (category.imageURL !== null) {
                    htmlData += `
                                    <div class="col-lg-10 col-md-8">
                                        <h3>
                                            ${category.title}
                                            ${catTitleExtra}
                                            ${catDescription}
                                        </h3>
                                    </div>
                                    <div class="col-lg-2 col-md-4 gallery">
                                        <a href="${category.imageURL}" data-toggle="lightbox" data-gallery="FishAndChipsGallery" data-title="" data-footer="Bells Fish Shop">
                                            <img src="${category.thumbnailURL}" class="img-fluid img-thumbnail">
                                        </a>
                                    </div>`;
                }
                else {
                    htmlData += `
                                    <div class="col-md">
                                        <h3>
                                            ${category.title}
                                            ${catTitleExtra}
                                            ${catDescription}
                                        </h3>
                                    </div>`;
                }

                htmlData += `
                                </div>
                                <div class="row">
                                    <div class="col-md">`;

                htmlData += `
                                        <table class="table table-striped table-dark">
                                            <tbody>`;

                for (let itm in category.menuItem) {
                    let item = category.menuItem[itm];
                    let titleExtra = "";
                    let description = "";
                    numItemInColumn += 1;

                    if (item.titleExtra !== null) {
                        titleExtra = ` <small class="text-muted">${item.titleExtra}</small>`;
                    }

                    if (item.description !== null) {
                        description = `
                            <br />
                            <small class="text-muted">
                                ${item.description}
                            </small>`;
                    }

                    if (numItemInColumn > numItemsPerColumn) {
                        //Add new column and reset count
                        numItemInColumn = 1;

                        htmlData += `
                                            </tbody>
                                        </table>
                                    </div>

                                    <div class="col-md">
                                        <table class="table table-striped table-dark">
                                            <tbody>`;
                    }


                    htmlData += `
                                                <tr>
                                                    <td>
                                                        ${item.title}
                                                        ${textReplacements(titleExtra)}
                                                        ${description}
                                                    </td>
                                                    <td class="text-right">${currency.format(item.price)}</td>
                                                </tr>`;
                }

                htmlData += `
                                            </tbody>
                                        </table>
                                    </div>
                                </div>`;

                if (isAdmin === "True" && kioskScreen <= 0) {
                    htmlData += `
                                <div class="row">
                                    <div class="col-md">
                                        <div class="alert alert-primary text-right" role="alert">
                                            <button type="button" class="btn btn-dark EditMenu" data-toggle="modal" data-target="#MenuCategoryModal" data-id="${category.menuCategoryID}"><i class="fas fa-edit"></i> Edit...</button>
                                        </div>
                                    </div>
                                </div>`;
                }

                htmlData += `
                            </div>
                        </div>
                    </div>
                </div>`;
            }
        }

        $("#MenuData").html(htmlData);
        menuLoadComplete();
    }
    catch (e) {
        let title = `Error Displaying Menu Data`;
        let content = `Sorry an error occurred displaying the menu data. Please refresh the page to try again`;

        doErrorModal(title, content);
    }
}

function menuLoadComplete() {
    $(".EditMenu").click(function (event) {
        let menuCategoryID = $(this).attr("data-id");

        $("#MenuCategoryID").val(menuCategoryID);
    });
}

function menuCategoryLoadComplete(objectID, relativeURL, modelToClose) {
    attachSubmitInputForm("MenuCategoryForm", objectID, relativeURL, "MenuCategoryModal");
}

function menuItemListLoadComplete(objectID, relativeURL, modelToClose) {
    $(".EditMenuItem").click(function (event) {
        let menuItemID = $(this).attr("data-id");
        $("#MenuItemID").val(menuItemID);
    });

    $('[data-toggle="popover"]').popover();

    var cols = document.querySelectorAll('table.sortable tr');
    [].forEach.call(cols, function (col) {
        col.addEventListener('dragstart', handleDragStart, false);
        col.addEventListener('dragenter', handleDragEnter, false)
        col.addEventListener('dragover', handleDragOver, false);
        col.addEventListener('dragleave', handleDragLeave, false);
        col.addEventListener('drop', handleDrop, false);
        col.addEventListener('dragend', handleDragEnd, false);
    });

    var draggedRow = null;
    var draggedRowID = null;
    var destinationRowID = null;

    function handleDragStart(e) {
        this.style.opacity = '0.4';

        draggedRow = this;
        draggedRowID = draggedRow.getAttribute("data-id");
        e.dataTransfer.effectAllowed = 'move';
        e.dataTransfer.setData('text/html', this.innerHTML);
    }

    function handleDragOver(e) {
        if (e.preventDefault) {
            e.preventDefault();
        }

        e.dataTransfer.dropEffect = 'move';

        return false;
    }

    function handleDragEnter(e) {
        this.classList.add('over');
    }

    function handleDragLeave(e) {
        this.classList.remove('over');
    }

    function handleDrop(e) {
        if (e.stopPropagation) {
            e.stopPropagation();
        }

        // Don't do anything if dropping row back where it was.
        if (draggedRow != this) {
            // Switch the row content between the source and destination row
            draggedRow.innerHTML = this.innerHTML;
            this.innerHTML = e.dataTransfer.getData('text/html');

            // Switch the IDs
            destinationRowID = this.getAttribute("data-id");
            draggedRow.setAttribute("data-id", destinationRowID);
            this.setAttribute("data-id", draggedRowID);

            updateMenuItemPositions(draggedRow);
        }

        return false;
    }

    function handleDragEnd(e) {
        this.style.opacity = '1';

        [].forEach.call(cols, function (col) {
            col.classList.remove('over');
        });
    }
}

function updateMenuItemPositions(row) {
    let menuTable = row.parentElement.parentElement;
    let menuCategoryID = menuTable.getAttribute("data-id");
    let itemOrder = 0;
    let sqlRow = ``;
    let sqlRows = null;

    for (const row of menuTable.rows) {
        let itemID = row.getAttribute("data-id");

        if (itemID !== null) {
            itemOrder += 1;

            sqlRow = `(${itemID}, ${itemOrder})`;

            if (sqlRows === null) {
                sqlRows = sqlRow;
            }
            else {
                sqlRows += ', ' + sqlRow;
            }
        }
    }

    alert(sqlRows);
    //let items = [];
    //[].forEach.menuItem(items, function (item) {
    //    items.push(item.getAttribute("data-id"));
    //});

    //console.log(items);

}

function menuItemLoadComplete(objectID, relativeURL, modelToClose) {
    attachSubmitInputForm("MenuItemForm", objectID, relativeURL, "MenuItemModal");
}


$(".SaveMenuCategoryButton").click(function (event) {
    checkApplyOrOkClicked($(this).text());
    $("#MenuCategoryForm form").submit();
});

$(".SaveMenuItemButton").click(function (event) {
    checkApplyOrOkClicked($(this).text());
    $("#MenuItemForm form").submit();
});

function checkApplyOrOkClicked(button) {
    if (button.includes("OK")) {
        $("#CloseFormOnSubmit").val("Y");
    }
    else {
        $("#CloseFormOnSubmit").val("N");
    }
}

function attachSubmitInputForm(formToSubmit, objectID, relativeURL, modelToClose) {
    let form = $("#" + formToSubmit + " form");
    form.removeData('validator');
    form.removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse(form);

    form.submit(function (event) {
        event.preventDefault();

        //If existing item then update
        if (objectID.length > 0) {
            //If no unobtrusive validation errors
            if (form.valid()) {
                $.ajax({
                    type: "POST",
                    url: "/" + relativeURL + "/Edit/" + objectID,
                    data: form.serialize(),
                    success: function (data) {
                        if ($("#CloseFormOnSubmit").val() === "Y") {
                            $("#" + modelToClose).modal("hide");
                        }
                        console.log("Object " + objectID + " Updated: " + dataToLoad);
                        var audio = new Audio("/sounds/confirm.wav");
                        audio.play();
                        //Refresh screen
                    },
                    error: function (error) {
                        doCrashModal(error);
                    }
                });
            }
        }
        else {
            //If no unobtrusive validation errors
            if (form.valid()) {
                $.ajax({
                    type: "POST",
                    url: "/" + relativeURL + "/Create",
                    data: form.serialize(),
                    success: function (data) {
                        let hasClosedModal = false;
                        if (closeFormOnSubmit === "Y") {
                            hasClosedModal = true;
                            $("#" + modelToClose).modal("hide");
                        }
                        console.log("New Object Created: " + dataToLoad);
                        var audio = new Audio("/sounds/confirm.wav");
                        audio.play();

                        //Now object created must switch to edit mode
                        if (!hasClosedModal) {
                            $("#" + objectIDField).val(data.objectID);
                            $("#" + modelToClose).trigger("shown.bs.modal");
                        }

                        loadList(
                            loadListIntoDivID,
                            relativeURL,
                            "Index",
                            parentObjectID,
                            listToRefresh,
                            listQueryParams,
                            listButtonClass,
                            listSortCol,
                            listSortOrder,
                            objectIDField
                        );
                    },
                    error: function (error) {
                        doCrashModal(error);
                    }
                });
            }
        }
    });
}

$(".SearchMenu").keyup(function (event) {
    let search = $(this).val();

    if (search.length > 0) {
        $(".ClearSearch").removeClass("d-none");
    }
    else {
        $(".ClearSearch").addClass("d-none");
    }

    filterMenu(search);
});

$(".ClearSearch").click(function (event) {
    $(".SearchMenu").val("");
    $(".SearchMenu").trigger("keyup");
});

function filterMenu(search) {
    return new Promise(resolve => {
        let data = JSON.parse(localStorage.getItem("menuData"));
        let menuData = data.menuData[0];

        for (let cat in menuData.menuCategory) {
            if (search.length > 1) {
                searchVal = search.toLowerCase();

                menuData.menuCategory[cat].menuItem = menuData.menuCategory[cat].menuItem.filter(
                    item =>
                        item.title.toLowerCase().indexOf(searchVal) !== -1
                );
            }
        }

        loadMenu(data);

        resolve(1);
    });
}