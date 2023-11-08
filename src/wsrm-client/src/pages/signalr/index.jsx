import { useEffect } from "react";
import api from '../../services';

export default function SignalR() {

  useEffect(() => {
    startConnection();
  }, []);

  const startConnection = () => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:7058/useBalanceHub")
      .build();

    connection.start();

    connection.on("UseBalance", (data) => {
      console.log(data);
    });
  }

  const sendMessage = () => {
    let data = {
      "industryId": 1937,
      "chainId": 1130,
      "periodId": 1000004252,
      "order": [
        {
          "orderId": 1001007656,
          "balance": 580
        }
      ]
    };

    api
      .post("/balance", data)
      .then(response => console.log(response))
      .catch(err => console.log(err));
  }

  return (
    <>
      <h1>Welcome to SignalR</h1>

      <button onClick={sendMessage}>Enviar Mensagem</button>
    </>
  );
}