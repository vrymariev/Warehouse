import format from 'date-fns/format';
import { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import { GoodType } from '../../Types/types';

const GoodsList = () => {
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [items, setItems] = useState<GoodType[]>([]);
    let history = useHistory();

    const fetchFromServer = () => {
        fetch("http://localhost:5000/goods")
        .then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        })
        .then((result) => {
            setIsLoaded(true);
            setItems(result);
        }).catch((error) => {
            setIsLoaded(true);
            setError(error.message);
        });
    };

    const redirect = (id: number) => {
        history.push('/editGood/' + id)
    };

    const deleteGood = (id: number) => {
        fetch('http://localhost:5000/goods/' + id, {method: 'DELETE'})
        .then((response) => {
            if (!response.ok) {
                throw new Error('Something went wrong');
            }
        })
        .then((result) => {
            fetchFromServer();
        }).catch((error) => {
            setError(error.message);
        });
    };

    useEffect(() => {
        fetchFromServer();
    }, []);

    const AddGood = () => {
        history.push('/addGood');
    };

    if (error) {
        return <div>Error: {error}</div>;
    } else if (!isLoaded) {
        return <div>Loading...</div>;
    } else {
        return (
            <div>
                <button onClick={() => AddGood()}>Додати</button>
                <table style={{"borderWidth":"1px", 'borderColor':"#aaaaaa", 'borderStyle':'solid'}}>
                    <thead>
                        <tr>
                            <td>Товар</td>
                            <td>Кількість</td>
                            <td>Ціна</td>
                            <td>Дата реєстрації</td>
                            <td></td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
                    {items.map((item, index) => {     
                        var date = new Date(item.registrationDate);
                        var formattedDate = format(date, 'dd-MM-yyyy');
                        return (
                            <tr key={index}>
                                <td>{item.name}</td>
                                <td>{item.count}</td>
                                <td>{item.price}</td>
                                <td>{formattedDate}</td>
                                <td><button onClick={() => redirect(item.id)}>Редагувати</button></td>
                                <td><button onClick={() => deleteGood(item.id)}>Видалити</button></td>
                            </tr>
                        ) 
                    })}
                    </tbody>
                </table>
            </div>
        );
    }

}

export default GoodsList;