import React from "react";
import Login from "./Login"
import NewRoomButton from "./NewRoomButton";
import { Button } from "react-bootstrap";
import Slider from 'react-input-slider';
import { useState } from "react";

const Rooms = ({ rooms , joinRoom, createRoom, user}) => {
    const [enterMoney, setEnterMoney] = useState({ x: parseInt(user.money/2) });

    return(
    <div id = "room-list" className='room-list'>
        <h4 id = "availableRooms">Available Rooms</h4>
        <div>
            <label> {enterMoney.x} $ </label>
            <Slider xmin = {parseInt(user.money/10)} xmax = {user.money} x={enterMoney.x} onChange={({ x }) => setEnterMoney(enterMoney => ({ ...enterMoney, x }))} />
        </div>
        <NewRoomButton createRoom = {createRoom} user = {user} enterMoney = {enterMoney.x}/>
        {
            rooms.map(room=>(
                <Button key = {room.id} onClick={() => {joinRoom(room.id, enterMoney.x)}}>{room.name} {room.numberOfPlayers}/5</Button>
            ))
        }
    </div>);
};

export default Rooms;