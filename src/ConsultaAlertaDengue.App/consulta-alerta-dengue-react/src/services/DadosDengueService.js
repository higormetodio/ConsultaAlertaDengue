import axios from 'axios';
import { enviroment } from '../enviroment/enviroment';

const getNumeroSemana = (now) => {
    now = new Date(Date.UTC(now.getFullYear(), now.getMonth(), now.getDate()));
    now.setUTCDate(now.getUTCDate() + 4 - (now.getUTCDay() || 7));

    const anoInicio = new Date(Date.UTC(now.getFullYear(), 0, 1));
    const numeroSemana = Math.ceil(((now - anoInicio) / 86400000 + 1) / 7);

    return numeroSemana;
};

const getSemanaAnoAtual = (semanaPassada = 0) => {
    const hoje = new Date();
    hoje.setDate(hoje.getDate() - semanaPassada * 7);

    const ano = hoje.getFullYear();
    const semana = getNumeroSemana(hoje);

    return { semana, ano }
};

const GetDadosDengue = async () => {
    const semanaDesejada = 1;

    const { semana: semana1, ano: ano1 } = getSemanaAnoAtual(semanaDesejada);
    const { semana: semana2, ano: ano2 } = getSemanaAnoAtual(semanaDesejada + 1);
    const { semana: semana3, ano: ano3 } = getSemanaAnoAtual(semanaDesejada + 2);

    const endpoint1 = `${enviroment.apiUrl}/?semana=${semana3}&ano=${ano3}`;
    const endpoint2 = `${enviroment.apiUrl}/?semana=${semana2}&ano=${ano2}`;
    const endpoint3 = `${enviroment.apiUrl}/?semana=${semana1}&ano=${ano1}`;

    console.log('Endpoints gerados:', endpoint1, endpoint2, endpoint3);

    try {
        const [retorno1, retorno2, retorno3] = await Promise.all([
            axios.get(endpoint1),
            axios.get(endpoint2),
            axios.get(endpoint3),
        ]);

        console.log('Dados retornados:', retorno1.data, retorno2.data, retorno3.data);

        // Transformar os objetos em um array para evitar erros de "não iterável"
        const dado1 = [retorno1.data]; // Envolva em array
        const dado2 = [retorno2.data]; // Envolva em array
        const dado3 = [retorno3.data]; // Envolva em array

        // Combina todos os dados em um único array
        const dadosCombinados = [...dado1, ...dado2, ...dado3];
        return dadosCombinados;
    } catch (error) {
        console.error('Erro ao buscar os dados da API:', error);
        return [];
    }
};

export { GetDadosDengue };
