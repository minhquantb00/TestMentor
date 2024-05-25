import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const courseApi = defineStore("course", {
  actions: {
    createCourse(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post(
            "/Admin/CreateCourse",
            { ...params },
            {
              headers: {
                "Content-Type": "multipart/form-data",
                Authorization: `Bearer ${authorization}`,
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    updateCourse(params) {
      return new Promise((resolve, reject) => {
        // Đối với hàm updateCourse, bạn cần truyền ID của khóa học cần cập nhật
        axiosIns
          .put(
            "/User/UpdateCourse/",
            { ...params },
            {
              headers: {
                "Content-Type": "multipart/form-data",
                Authorization: `Bearer ${authorization}`,
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    searchCourses(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .get("/User/GetAllCourse", { ...params })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getAllCourses() {
      return new Promise((resolve, reject) => {
        axiosIns
          .get("/User/GetAllCourse")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
    getAllCoursesByUserId(id) {
      return new Promise((resolve, reject) => {
        axiosIns
          .get(`/User/GetCourseByUserId/${id}`)
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              s;
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
    deleteCourses(khoaHocId) {
      return new Promise((resolve, reject) => {
        axiosIns
          .delete(`/User/DeleteCourse/${khoaHocId}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => {
            if (res.status === 200) {
              // Sửa từ response thành res
              resolve(res.data);
            } else {
              reject(res); // Sử dụng res thay vì error
            }
          })
          .catch((error) => reject(error));
      });
    },
    getCourseId(id) {
      return new Promise((resolve, reject) => {
        axiosIns
          .get(`/User/GetCourseById/${id}`)
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
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
