loadMenu();

//Format numbers to currency
var currency = new Intl.NumberFormat('en-GB', {
    style: 'currency',
    currency: 'GBP'
});

function textReplacements(txt) {
    txt = txt.replace('(V)', '<span class="veg-vegetarian"></span>');
    txt = txt.replace('(GF)', '<span class="glutenfree-gf1"></span><span class="glutenfree-gf2"></span>');
    return txt;
}

function loadMenu() {
    let menu = $("#MenuRef").val();

    let dataToLoad = `/MenuData/${menu}/?handler=Json`;

    $.get(dataToLoad, function (data) {

    })
        .then(data => {
            //First and only in array of menus - would allow drinks menu to be on same page
            var menuData = data.menuData[0];

            try {
                let htmlData = "";
                for (let cat in menuData.menuCategory) {
                    let category = menuData.menuCategory[cat];
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
                        <div class="col-xl-4 col-md-6 Spacer">
                            <div class="MainContent MenuContent">
                                <h3>
                                    ${category.title}
                                    ${catTitleExtra}
                                    ${catDescription}
                                </h3>
                                <table class="table table-striped">
                                    <tbody>`;

                    for (let itm in category.menuItem) {
                        let item = category.menuItem[itm];
                        let titleExtra = "";
                        let description = "";

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
                }

                $("#MenuData").html(htmlData);

                console.log(dataToLoad + " Loaded");
            }
            catch (e) {
                doErrorModal("Error Loading Menu Data", "Sorry an error occurred loading the menu data. Please check your internet connection and try again.");
            }
        })
        .fail(function () {
            let title = `Error Loading Search Results`;
            let content = `Sorry an error occurred loading the list of courses. Please try again.`;

            doErrorModal(title, content);
        });
}