document.addEventListener("DOMContentLoaded", ()=> {
    console.log("se ha conectado el js");

    const divsContenedoresProductosCarrito = document.querySelectorAll(".div-contenedor-producto")
    divsContenedoresProductosCarrito.forEach(div => {
        div.addEventListener('click', () => {
        console.log(div);
        })
});

});



