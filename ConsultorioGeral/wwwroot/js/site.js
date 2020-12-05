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