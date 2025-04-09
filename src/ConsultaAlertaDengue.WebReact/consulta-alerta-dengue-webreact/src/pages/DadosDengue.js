import React, { useEffect, useState } from "react";
import { Layout, Typography, Card } from 'antd';
import { GetDadosDengue } from "../services/DadosDengueService";

const { Header, Footer, Content } = Layout;
const { Title } = Typography;

const DadosDengue = () => {
    const [data, setData] = useState([]);
    const [selectedItem, setSelectedItem] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            const dados = await GetDadosDengue();
            setData(dados);
        };

        fetchData();
    }, []);

    const handleRowClick = (item) => {
        setSelectedItem(item);
    };

    return (
        <Layout>
            <Header style={{ textAlign: 'center', color: '#fff' }}>
                <Title level={2} style={{ color: '#fff' }}>Consulta Dados Dengue</Title>
            </Header>
            <Content style={{ padding: '50px', display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                <table style={{ width: '80%', borderCollapse: 'collapse' }}>
                    <thead>
                        <tr style={{ backgroundColor: '#f0f0f0' }}>
                            <th style={{ border: '1px solid #ccc', padding: '8px' }}>Semana Epidemiológica</th>
                            <th style={{ border: '1px solid #ccc', padding: '8px' }}>Casos Notificados</th>
                            <th style={{ border: '1px solid #ccc', padding: '8px' }}>Casos Estimados</th>
                            <th style={{ border: '1px solid #ccc', padding: '8px' }}>Nível de Alerta</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((item, index) => (
                            <tr
                                key={index}
                                onClick={() => handleRowClick(item)}
                                style={{ cursor: 'pointer', backgroundColor: index % 2 === 0 ? '#f9f9f9' : '#fff' }}
                            >
                                <td style={{ border: '1px solid #ccc', padding: '8px' }}>{item.semanaEpidemiologica}</td>
                                <td style={{ border: '1px solid #ccc', padding: '8px' }}>{item.casosNotificados}</td>
                                <td style={{ border: '1px solid #ccc', padding: '8px' }}>{item.casosEstimados}</td>
                                <td style={{ border: '1px solid #ccc', padding: '8px' }}>{item.nivelAlerta}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>

                {selectedItem && (
                    <Card style={{ marginTop: '20px', width: 300 }}>
                        <p>Semana Epidemiológica: {selectedItem.semanaEpidemiologica}</p>
                        <p>Casos Notificados: {selectedItem.casosNotificados}</p>
                        <p>Casos Estimados: {selectedItem.casosEstimados}</p>
                        <p>Nível de alerta: {selectedItem.nivelAlerta}</p>
                    </Card>
                )}
            </Content>
            <Footer style={{ textAlign: 'center' }}>
                <Title level={5}>©2025 Consulta Dados Dengue</Title>
            </Footer>
        </Layout>
    );
};

export default DadosDengue;
