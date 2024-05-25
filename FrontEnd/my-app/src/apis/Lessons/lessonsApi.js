import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";

// Định nghĩa baseURL cho axios
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const lessonsApi = defineStore("lessons", {
  actions: {
    createLessons(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post(
            "/User/CreateLesson",
            { ...params },
            {
              headers: {
                Authorization: `Bearer ${authorization}`,
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getAllLessons() {
      return new Promise((resolve, reject) => {
        axiosIns
          .get("/user/GetAllsBaiHoc")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              console.log(res);
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
    getAllCoursesType() {
      return new Promise((resolve, reject) => {
        axiosIns
          .get("/user/GetAllLKH")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              console.log("Loại khóa học");
              console.log(res);
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
  },
});
