$("#select-especialidade").change(function () {
    let especialidade = $(this).val();
    $.ajax({
        url: '/Consulta/ObterMedicosPorEspecialidade',
        data: { especialidade },
        type: 'POST',
        success: function (result) {

            let selectBox = $("#select-medicos");
            selectBox.empty();

            selectBox.append($('<option>', {
                value: "",
                text: "Selecione o Médico",
            }));

            $.each(result.data, function (i, item) {
                selectBox.append($('<option>', {
                    value: item.medicoId,
                    text: item.nome,
                }));
            });
        }
    });
});

//JS PARA RESPOSTA DE DIAGNOSTICO

$(".enviar-diagnostico").click(function () {
    console.log('cliquei')
    let diagnostico = $(".diagnostico-medico").val();
    let consultaId = $(this).data("id");
    console.log(diagnostico)
    console.log(consultaId)

    $.ajax({
        url: '/MedicoView/ResponderDiagnostico',
        data: {
            consultaId: consultaId,
            diagnostico: diagnostico
        },
        type: 'POST',
        success: function (result) {
            location.reload();
        }
    });
});
