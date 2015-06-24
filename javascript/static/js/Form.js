/**
 * Created by net04 on 23/06/2015.
 */
function ShowHideField(checkbox, element) {
    // toggle element visibility
    if (element && checkbox.tagName == "INPUT" && checkbox.type == "checkbox") {
        var fields = element.getElementsByTagName('input');
        var on = (checkbox.checked);
        if (on = true) {
            element.style.display = "inline";
            element.focus();
        }
        else {
            element.style.display = "none";
            for (var i = 0; i < fields.length; i++) {
                if (fields[i].type == "checkbox") {
                    fields[i].checked = false;
                }
                else {
                    fields[i].value = "";
                }
            }
        }
    }
}